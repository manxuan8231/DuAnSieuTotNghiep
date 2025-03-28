using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//code nay them vao cinemachine
public class ContentRadioQuest1 : MonoBehaviour
{
    public RawImage image;
    public TextMeshProUGUI TextMeshProUGUI;
    public string[] content;
    [SerializeField] private LayerMask radioLayer;
    void Start()
    {
        image.gameObject.SetActive(false);
        TextMeshProUGUI.gameObject.SetActive(false);
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
        TextMeshProUGUI.gameObject.SetActive(true);
        image.gameObject.SetActive(true);

        for (int i = 0; i < content.Length; i++)
        {
            TextMeshProUGUI.text = "";

            foreach (var item in content[i])
            {
                TextMeshProUGUI.text += item;
                yield return new WaitForSecondsRealtime(0.05f); // Dùng WaitForSecondsRealtime để chạy dù Time.timeScale = 0
            }
            yield return new WaitForSecondsRealtime(3f); // Tạm dừng giữa các câu
        }

        yield return new WaitForSecondsRealtime(3f);

        TextMeshProUGUI.gameObject.SetActive(false);
        image.gameObject.SetActive(false);

        Time.timeScale = 1; // Tiếp tục game
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckItemPaper();

    }

}
