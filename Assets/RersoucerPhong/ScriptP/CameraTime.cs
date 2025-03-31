using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Transform targetPosition;
    public float speed = 2.0f;

    private bool isMoving = true;

    void Start()
    {
        SetupCamera1();
    }

    void Update()
    {
        if (isMoving)
        {
            MoveCamera1();
        }
    }

    void SetupCamera1()
    {
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
        camera1.transform.position = new Vector3(0, 5, -10); // Thiết lập vị trí ban đầu của camera1
        camera1.transform.LookAt(targetPosition); // Hướng camera1 về mục tiêu
    }

    void MoveCamera1()
    {
        camera1.transform.position = Vector3.MoveTowards(camera1.transform.position, targetPosition.position, speed * Time.deltaTime);

        if (Vector3.Distance(camera1.transform.position, targetPosition.position) < 0.1f)
        {
            SwitchToCamera2();
        }
    }

    void SwitchToCamera2()
    {
        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(true);
        isMoving = false;
    }
}