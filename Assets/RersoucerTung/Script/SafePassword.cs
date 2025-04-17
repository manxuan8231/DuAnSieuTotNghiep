using TMPro;
using UnityEngine;

public class SafePassword : MonoBehaviour
{
    public TMP_InputField pass1;
    public TMP_InputField pass2;
    public TMP_InputField pass3;
    public string correctCode = "154"; // Mã đúng
    public Animator animator;
    public bool isPasswordCorrect = false;
    PasswordSafeBox passwordSafeBox;
    void Start()
    {
        passwordSafeBox = FindAnyObjectByType<PasswordSafeBox>();   
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckPassword()
    {
        string inputCode = pass1.text + pass2.text + pass3.text;

        if (inputCode == correctCode)
        {
            animator.SetTrigger("SafeOpen");
            isPasswordCorrect = true;
            Cursor.lockState = CursorLockMode.Locked; // Ẩn con trỏ chuột
            Cursor.visible = false;
            passwordSafeBox.canvasPasswordSafeBox.SetActive(false);

        }
        else
        {

        }
    }
}

