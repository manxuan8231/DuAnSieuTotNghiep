using UnityEngine;

public class GlassFollow : MonoBehaviour
{
    public string targetName = "hand_r"; // Tên object cần tìm
    public Vector3 localOffset = new Vector3(0.08f, -0.225f, 0.228f); // Vị trí lệch khi đã là con
    public Vector3 localEulerAngles = new Vector3(-31.305f, -183.075f, -98.276f); // Góc xoay local

    void Start()
    {
        GameObject foundObject = GameObject.Find(targetName);

        if (foundObject != null)
        {
            Transform target = foundObject.transform;

            // Gắn làm con trong hierarchy
            transform.SetParent(target);

            // Đặt vị trí local theo offset
            transform.localPosition = localOffset;

            // Đặt xoay local theo Euler angles (độ)
            transform.localRotation = Quaternion.Euler(localEulerAngles);
        }
        else
        {
            Debug.LogWarning($"Không tìm thấy object có tên '{targetName}' trong scene.");
        }
    }
}
