using UnityEngine;


public class PlayerUpshot : MonoBehaviour
{
    private Animator animator;
    public CameraFollowHead cameraFollowHead;
    private CharacterController characterController;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void PlayerUpShot(Transform enemy)
    {
        // Gọi animation
        animator.SetTrigger("HitDown");
        cameraFollowHead.rotation = false;
        characterController.height = 1f;
        characterController.center = new Vector3(0, 0.57f, 0);
    }
}
