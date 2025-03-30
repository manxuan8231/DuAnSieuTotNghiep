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


    // Stick 

    public LayerMask StickMask;
    public TextMeshProUGUI textContentStick;
    public CinemachineCamera cameraPlayerStick;
    public CinemachineCamera cameraStick;
    public GameObject stick;


    //Diary

    public LayerMask DiaryMask;
    public TextMeshProUGUI textContentDiary;
    public CinemachineCamera cameraPlayerDiary;
    public CinemachineCamera cameraDiary;
    public GameObject diary;
    void Start()
    {
        textContent.gameObject.SetActive(false);
        textContentStick.gameObject.SetActive(false);
        textContentDiary.gameObject.SetActive(false);
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
        if(Physics.Raycast(transform.position, transform.forward, out var hit3, 5, DiaryMask))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(ChangeCameraDiary());
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
    

    }

    //routine Diary
    IEnumerator ChangeCameraDiary()
    {
        cameraDiary.Priority = 20;
        cameraPlayerDiary.Priority = 0;
        yield return new WaitForSecondsRealtime(1f);
        textContentDiary.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        cameraDiary.Priority = 0;
        cameraPlayerDiary.Priority = 10;
        yield return new WaitForSecondsRealtime(2f);
        textContentDiary.gameObject.SetActive(false);
        Destroy(diary);
    }

    void Update()
    {
        CheckItem();
    }
}
