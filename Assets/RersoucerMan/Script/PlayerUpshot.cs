using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerUpshot : MonoBehaviour
{
    private Animator animator;
    public CameraFollowHead cameraFollowHead;
    private CharacterController characterController;
    public GameObject panel;
    public int scene;
    private void Start()
    {
        panel.SetActive(false);
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
        StartCoroutine(ChangeScene() );
    }
    public IEnumerator ChangeScene()
    {

        panel.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(scene);
    }
}
