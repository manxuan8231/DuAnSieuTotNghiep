using TMPro;
using UnityEngine;

public class ButtonE : MonoBehaviour
{
    public TextMeshProUGUI textActiveE;
    public CommenEvenGuong commenEvenGuong;

   
    void Start()
    {
      
        commenEvenGuong = FindAnyObjectByType<CommenEvenGuong>();
        textActiveE.text = $"Bấm E để kích hoạt";
    } 
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Glass") && commenEvenGuong.isClick)
        {         
            textActiveE.enabled = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Glass"))
        {
            textActiveE.enabled = false;
        }
    }
}
