using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Cài đặt nhân vật")]
    [SerializeField] private float moveSpeed = 5f;   // Tốc độ di chuyển
    [SerializeField] private float jumpForce = 10f;   // Lực nhảy
    [SerializeField] private float sprintSpeed = 8f; // Tốc độ chạy nhanh khi giữ Shift
    [SerializeField] private CharacterController controller; // Đối tượng CharacterController

    private Rigidbody rb;
    private Animator animator;
    private Vector3 movement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
       
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
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);
       /* velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);*/
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           /* rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);*/
            
        }
    }
}
