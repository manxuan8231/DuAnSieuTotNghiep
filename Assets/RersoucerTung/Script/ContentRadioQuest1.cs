using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//code nay them vao cinemachine
public class ContentRadioQuest1 : MonoBehaviour
{
    public RawImage image;
    [SerializeField] private LayerMask radioLayer;
    Radio radio;
    void Start()
    {
        image.gameObject.SetActive(false);
       
        radio = GameObject.FindAnyObjectByType<Radio>();
    }



    void CheckItemPaper()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 5, radioLayer))
        {
            // Vẽ ray chỉ khi có va chạm
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
           
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                StartCoroutine(pauseGame());
                

            }
        }

    }
    IEnumerator pauseGame()
    {
        Time.timeScale = 0; // Dừng game
        StartCoroutine(WatchRadioText1());
        yield return new WaitForSecondsRealtime(0.1f); // Chạy đúng ngay cả khi Time.timeScale = 0
    }
    IEnumerator WatchRadioText1()
    {
      
        image.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        image.gameObject.SetActive(false);
       
        Time.timeScale = 1; // Tiếp tục game
        radio.OnBox();
    }

    // Update is called once per frame
    void Update()
    {
        CheckItemPaper();

    }

}
