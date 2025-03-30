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

    void Start()
    {
        textContent.gameObject.SetActive(false);
    }


    //xem picture

    void CheckItemPickture()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 5, PicktureMask))
        {
            // Vẽ ray chỉ khi có va chạm
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            
           if(Input.GetKeyDown(KeyCode.E))
            {
               StartCoroutine(ChangeCamera());
               
            }
        }

    }
  
    IEnumerator ChangeCamera()
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
    
    void Update()
    {
       
            CheckItemPickture();

   
           
    }
}
