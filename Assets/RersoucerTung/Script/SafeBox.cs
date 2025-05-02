using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class SafeBox : MonoBehaviour
{
    public Animator animator;
    public GameObject canvasPasswordSafeBox;
    public LayerMask layerSafeboxPass;
    SafePassword safePassword;
    DiaryQuest diaryQuest;
    void Start()
    {

        canvasPasswordSafeBox.SetActive(false);
        safePassword = FindAnyObjectByType<SafePassword>();
        diaryQuest = FindAnyObjectByType<DiaryQuest>();
    }
    void Update()
    {
        CheckItem();
    }
    void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 5, layerSafeboxPass))
        {
            // Vẽ ray chỉ khi có va chạm
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            if (Input.GetKeyDown(KeyCode.E))
            {
                canvasPasswordSafeBox.SetActive(true);
                Cursor.lockState = CursorLockMode.None; // Hiện con trỏ chuột
                Cursor.visible = true; // Hiện con trỏ chuột
            }
            if (safePassword.isPasswordCorrect)
            {
                canvasPasswordSafeBox.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked; // Ẩn con trỏ chuột
                Cursor.visible = false; // Ẩn con trỏ chuột
                diaryQuest.boxCollider.enabled = true; // Kích hoạt collider
            }
        }
    }
   
}
