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
        cameraPicture.Priority = 20;
        cameraPlayer.Priority = 0;
        yield return new WaitForSecondsRealtime(1f);
        textContent.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        textContent.gameObject.SetActive(false);
        cameraPicture.Priority = 0;
        cameraPlayer.Priority = 10;
      
    }
    
    void Update()
    {
        CheckItemPickture();
    }
}
