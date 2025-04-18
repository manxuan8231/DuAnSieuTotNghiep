using TMPro;
using UnityEngine;

public class Guong : MonoBehaviour
{
    public int id;
    public bool isActive;

    public CommenEvenGuong suKienGuong;

    void Start()
    {
        suKienGuong = FindAnyObjectByType<CommenEvenGuong>();
       
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isActive)
        {          
            suKienGuong.KiemTraGuong(this);
        }
    }
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActive = true;
           
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActive = false;
           
        }
    }
}
