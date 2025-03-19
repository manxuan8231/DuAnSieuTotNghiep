using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class Question1 : MonoBehaviour
{


    
    public BoxCollider boxCollider;
    public CinemachineCamera cineMachinePaPer1;
    public CinemachineCamera cineMachinePlayer;
    public TextMeshProUGUI NPCContent; // Nội dung hội thoại
    public string[] content; // Nội dung hội thoại
    void Start()
    {
        NPCContent.gameObject.SetActive(false);
        boxCollider = GetComponent<BoxCollider>();
      
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(CameraPaper1());
           
            
        }
    }
    IEnumerator CameraPaper1()
    {
        cineMachinePaPer1.Priority = 20;
        cineMachinePlayer.Priority = 0;
        yield return new WaitForSeconds(1f);
        StartCoroutine(ReadContent());
        yield return new WaitForSeconds(3f);
        cineMachinePaPer1.Priority = 0;
        cineMachinePlayer.Priority = 10;
    }
    private IEnumerator ReadContent()
    {
       NPCContent.gameObject.SetActive(true);
        for (int i = 0; i < content.Length; i++)
        {
            NPCContent.text = "";
          

            foreach (var item in content[i])
            {
                NPCContent.text += item;
                yield return new WaitForSeconds(0.05f); // Tốc độ chạy chữ
            }
            yield return new WaitForSeconds(1f); // Thời gian ngừng giữa các câu
        }
        yield return new WaitForSeconds(3f);
        NPCContent.gameObject.SetActive(false);
        boxCollider.enabled = false;
       
    }

    void Update()
    {
        
    }
}
