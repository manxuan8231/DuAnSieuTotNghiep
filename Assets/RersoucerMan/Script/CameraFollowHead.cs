using UnityEngine;

public class CameraFollowHead : MonoBehaviour
{
    [SerializeField] private float sensX = 100f; // Độ nhạy chuột theo trục X
    [SerializeField] private float sensY = 100f; // Độ nhạy chuột theo trục Y
    [SerializeField] private Transform playerHead; // Đối tượng đầu của Player
    [SerializeField] private Transform orientation; // Hướng xoay của nhân vật
    [SerializeField] private float smoothSpeed = 10f; // Tốc độ di chuyển camera

    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Start()
    {
        // Ẩn và khóa con trỏ chuột
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {

       
        float mouseX = Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;

        // Xoay góc nhìn theo chuột
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Giới hạn góc nhìn lên/xuống

        // góc quay cho camera và nhân vật
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        if (orientation != null)
        {
            orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
        }

        // Di chuyển camera 
        transform.position = Vector3.Lerp(transform.position, playerHead.position, smoothSpeed * Time.deltaTime);
    }
}
