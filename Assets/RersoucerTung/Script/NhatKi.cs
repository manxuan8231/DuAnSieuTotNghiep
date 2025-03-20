using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NhatKi : MonoBehaviour
{




    public RawImage nhatKiImage;
    public TextMeshProUGUI nhatKiText;
    public AudioSource audioSource;
    public TextMeshProUGUI pickUpNhatKi;
    public string[] content;
    [SerializeField] private LayerMask nhatKiLayer;

    void Start()
    {
        
        nhatKiImage.gameObject.SetActive(false);
        nhatKiText.gameObject.SetActive(false);
        pickUpNhatKi.gameObject.SetActive(false);
    }
    void checkNhatKi()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 5, nhatKiLayer))
        {
            // Vẽ ray chỉ khi có va chạm
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            pickUpNhatKi.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) )
            {

                pickUpNhatKi.gameObject.SetActive(false);
                StartCoroutine(WatchNhatKiContent1());
                Destroy(hit.collider.gameObject);
            }
          
        }
    }
    IEnumerator WatchNhatKiContent1()
    {
        nhatKiImage.gameObject.SetActive(true);
        nhatKiText.gameObject.SetActive(true);
        
        for (int i = 0; i < content.Length; i++)
        {
            nhatKiText.text = "";
            foreach (var item in content[i])
            {
                nhatKiText.text += item;
                yield return new WaitForSeconds(0.05f); // Tốc độ chạy chữ
            }
            yield return new WaitForSeconds(5); // Thời gian ngừng giữa các câu

        }
        yield return new WaitForSeconds(3);
        nhatKiImage.gameObject.SetActive(false);
        nhatKiText.gameObject.SetActive(false);
       
    }
   
    private void Update()
    {
        checkNhatKi();
    }

}
