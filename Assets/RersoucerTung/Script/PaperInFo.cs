using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaperInFo : MonoBehaviour
{

    public RawImage ImagePaper1Info;
    public TextMeshProUGUI TextPaper1Info;
    [SerializeField] private LayerMask paperLayer;
    public TextMeshProUGUI pickUpPaper;
    public string[] content;
    void Start()
    {
        ImagePaper1Info.gameObject.SetActive(false);
        TextPaper1Info.gameObject.SetActive(false);
        pickUpPaper.gameObject.SetActive(false);
    }

  void CheckItemPaper()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 5, paperLayer))
        {
            // Vẽ ray chỉ khi có va chạm
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            pickUpPaper.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                UIEvenNhatKyBao get = FindAnyObjectByType<UIEvenNhatKyBao>();
                get.GetBao(1);
                pickUpPaper.gameObject.SetActive(false);
                StartCoroutine(pauseGame());
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            pickUpPaper.gameObject.SetActive(false);
        }

    }
    IEnumerator pauseGame()
    {
        Time.timeScale = 0; // Dừng game
        StartCoroutine(WatchPaper1());
        yield return new WaitForSecondsRealtime(0.1f); // Chạy đúng ngay cả khi Time.timeScale = 0
    }
    IEnumerator WatchPaper1()
    {

        ImagePaper1Info.gameObject.SetActive(true);
       TextPaper1Info.gameObject.SetActive(true);
        for (int i = 0; i < content.Length; i++)
        {
            TextPaper1Info.text = "";
          

            foreach (var item in content[i])
            {
                TextPaper1Info.text += item;
                yield return new WaitForSecondsRealtime(0.05f); // Tốc độ chạy chữ
            }
            yield return new WaitForSecondsRealtime(1f); // Thời gian ngừng giữa các câu
        }
        yield return new WaitForSecondsRealtime(3f);
        ImagePaper1Info.gameObject.SetActive(false);
        TextPaper1Info.gameObject.SetActive(false);

        Time.timeScale = 1; // Tiếp tục game
    }
    // Update is called once per frame
    void Update()
    {
        CheckItemPaper();

    }
}
