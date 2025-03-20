using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Cài đặt nhân vật")]
    [SerializeField] private float moveSpeed = 5f;   // Tốc độ di chuyển
    [SerializeField] private float sprintSpeed = 8f; // Tốc độ chạy nhanh khi giữ Shift 
    [SerializeField] private float crouchSpeed = 2f; // Tốc độ chạy khi ngồi
    [SerializeField] private float jumpForce = 10f;   // Lực nhảy  
    [SerializeField] private float gravity = -9.81f; // Trọng lực
    [SerializeField] private float resetTime = 0f;// Thời gian giữa các lần nhảy
    private Vector3 velocity;

    [Header("GetTaoLao")]
    private Animator animator;
    public CharacterController controller; // Đối tượng CharacterController

    [Header("Ke thua")]
    SliderUI sliderUI;

    
    private void Start()
    {
        sliderUI = FindAnyObjectByType<SliderUI>();
       
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MovePlayer();
        Jump();
        SitDown();
    }

    private void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; // Hướng di chuyển
        float currentSpeed = moveSpeed; // Tốc độ di chuyển bình thường

        // Kiểm tra nếu nhấn Shift thì tăng tốc độ chạy
        if (Input.GetKey(KeyCode.LeftShift) && sliderUI.CurrentMana() > 0)
        {

            sliderUI.runMana = true; // Trừ mana khi chạy

            currentSpeed = sprintSpeed; // Tốc độ chạy nhanh
            animator.SetBool("isRunning", true);
            
        }
        else
        {

            sliderUI.runMana = false;// Không trừ mana khi không chạy

            animator.SetBool("isRunning", false);
           
        }

        // Di chuyển nhân vật
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Animation đi bộ
        if (move.magnitude >= 0.1f)
        {
            sliderUI.walkMana = true; // Trừ mana khi đi bộ
            animator.SetBool("isWalking", true);
        }
        else
        {
            sliderUI.walkMana = false; // Không trừ mana khi không đi bộ
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        // Trọng lực
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= resetTime + 1)
        {
            animator.SetTrigger("Jump");
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            resetTime = Time.time;// Thời gian giữa các lần nhảy
        }
    }
    private void SitDown()
    {
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftControl))
        {
            moveSpeed = crouchSpeed; // Tốc độ chạy khi ngồi
            animator.SetBool("SitDown", true);
            controller.height = 1f;
            controller.center = new Vector3(0, 0.57f, 0);
        }
        else
        {
            moveSpeed = 5f; // Tốc độ chạy bình thường
            animator.SetBool("SitDown", false);
            controller.height = 1.86f;
            controller.center = new Vector3(0, 0.94f, 0);
        }
    }
}

