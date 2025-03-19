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
                
                pickUpPaper.gameObject.SetActive(false);
                StartCoroutine(WatchPaper1());
                Destroy(hit.collider.gameObject);
            }
        }
       
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
                yield return new WaitForSeconds(0.05f); // Tốc độ chạy chữ
            }
            yield return new WaitForSeconds(1f); // Thời gian ngừng giữa các câu
        }
        yield return new WaitForSeconds(3f);
        ImagePaper1Info.gameObject.SetActive(false);
        TextPaper1Info.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        CheckItemPaper();

    }
}
