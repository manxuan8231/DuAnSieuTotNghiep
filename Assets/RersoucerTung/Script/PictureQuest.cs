using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class PictureQuest : MonoBehaviour
{
    public LayerMask PicktureMask;
    public TextMeshProUGUI textContent;
    public CinemachineCamera cameraPlayer;
    public CinemachineCamera cameraPicture;
    public GameObject picture;
    public LinhHonTruongLang linhHonTruongLang;

    // Stick 

    public LayerMask StickMask;
    public TextMeshProUGUI textContentStick;
    public CinemachineCamera cameraPlayerStick;
    public CinemachineCamera cameraStick;
    public GameObject stick;


  
    void Start()
    {
        textContent.gameObject.SetActive(false);
        textContentStick.gameObject.SetActive(false);
       
        linhHonTruongLang = FindAnyObjectByType<LinhHonTruongLang>();
    }


    //xem raycast co cham vao doi tuong nao khong

    void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 5, PicktureMask))
        {
            // Vẽ ray chỉ khi có va chạm
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            
           if(Input.GetKeyDown(KeyCode.E))
            {
               StartCoroutine(ChangeCameraPicture());
               
            }
        }

        if(Physics.Raycast(transform.position, transform.forward, out var hit2, 5, StickMask))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(ChangeCameraStick());
            }
        }
       
    }
    //routie Stick
  IEnumerator ChangeCameraStick()
    {
        cameraStick.Priority = 20;
        cameraPlayerStick.Priority = 0;
        yield return new WaitForSecondsRealtime(1f);
        textContentStick.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        cameraStick.Priority = 0;
        cameraPlayerStick.Priority = 10;
        yield return new WaitForSecondsRealtime(2f);
        textContentStick.gameObject.SetActive(false);
        Destroy(stick);
        linhHonTruongLang.Item();
    }
    //routie Picture
    IEnumerator ChangeCameraPicture()
    {
    
     
        //Time.timeScale = 0; // Dừng game
        cameraPicture.Priority = 20;
        cameraPlayer.Priority = 0;
        yield return new WaitForSecondsRealtime(1f);
        textContent.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        cameraPicture.Priority = 0;
        cameraPlayer.Priority = 10;
        yield return new WaitForSecondsRealtime(2f);
        textContent.gameObject.SetActive(false);
        Destroy(picture);
        //Time.timeScale = 1; // Tiếp tục game
        linhHonTruongLang.Item();



    }
    void Update()
    {
        CheckItem();
    }
   
}
