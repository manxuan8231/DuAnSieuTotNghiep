using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Cài đặt nhân vật")]
    [SerializeField] private float moveSpeed = 5f;   // Tốc độ di chuyển
    [SerializeField] private float jumpForce = 8f;   // Lực nhảy
    [SerializeField] private float gravity = 9.81f;  // Trọng lực
    [SerializeField] private Transform cameraTransform; // Gán Camera vào Inspector
     private CharacterController controller; // Điều khiển nhân vật

    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {   
     controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovePlayer();
        ApplyGravity();
    }

    private void MovePlayer()
    {
        // Lấy input từ bàn phím
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Lấy hướng di chuyển theo góc của camera
        Vector3 moveDirection = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        moveDirection.y = 0; // Không di chuyển theo trục Y (tránh bị trượt)
        moveDirection.Normalize(); // Chuẩn hóa vector

        // Di chuyển nhân vật
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Xoay nhân vật theo hướng di chuyển
        if (moveDirection.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // Nhảy
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpForce;
        }
    }

    private void ApplyGravity()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Đảm bảo nhân vật không bị rơi liên tục
        }

        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
