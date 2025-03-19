using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaperInFo : MonoBehaviour
{

    public Image ImagePaper1Info;
    public TextMeshProUGUI TextPaper1Info;
    [SerializeField] private LayerMask paperLayer;
    public TextMeshProUGUI pickUpPaper;
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
        yield return new WaitForSeconds(5f);
        ImagePaper1Info.gameObject.SetActive(false);
        TextPaper1Info.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {CheckItemPaper();

    }
}
