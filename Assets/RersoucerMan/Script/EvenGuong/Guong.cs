using System.Collections;
using TMPro;
using UnityEngine;

public class Guong : MonoBehaviour
{
    public int id;
    public bool isActive;

    public CommenEvenGuong suKienGuong;

    public TextMeshProUGUI textActiveE;

    public GameObject[] light;
    void Start()
    {
        suKienGuong = FindAnyObjectByType<CommenEvenGuong>();
      
        textActiveE.text = $"Bấm E để kích hoạt";
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isActive)
        {          
            suKienGuong.KiemTraGuong(this);
            StartCoroutine(ColdownLight());
        }
    }
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && suKienGuong.isClick)
        {
            isActive = true;
            textActiveE.enabled = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActive = false;
            textActiveE.enabled = false;
        }
    }
    IEnumerator ColdownLight()
    {
        foreach (var item in light)
        {
            item.SetActive(false);
        }
        yield return new WaitForSeconds(0.5f);
        foreach (var item in light)
        {
            item.SetActive(true);
        }
    }
}
