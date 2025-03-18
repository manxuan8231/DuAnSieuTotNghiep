using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Cài đặt nhân vật")]
    [SerializeField] private float moveSpeed = 5f;   // Tốc độ di chuyển
    [SerializeField] private float jumpForce = 10f;   // Lực nhảy
    [SerializeField] private float sprintSpeed = 8f; // Tốc độ chạy nhanh khi giữ Shift
    [SerializeField] private CharacterController controller; // Đối tượng CharacterController
    [SerializeField] private float gravity = -9.81f; // Trọng lực

    private Animator animator;
    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MovePlayer();
        Jump();
    }

    private void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        isGrounded = controller.isGrounded; // Kiểm tra có chạm đất không
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Giữ nhân vật không trượt trên mặt đất
        }

        Vector3 move = transform.right * x + transform.forward * z;
        float currentSpeed = moveSpeed;

        // Kiểm tra nếu nhấn Shift thì tăng tốc độ chạy
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // Di chuyển nhân vật
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Animation đi bộ
        if (move.magnitude >= 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // Trọng lực
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetTrigger("Jump");
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }
}
