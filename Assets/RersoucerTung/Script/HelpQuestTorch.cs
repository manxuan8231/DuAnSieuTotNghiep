using TMPro;
using UnityEngine;

public class HelpQuestTorch : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject imgTorch;
    public TextMeshProUGUI viewText;
    void Start()
    {
        imgTorch.SetActive(false);
        viewText.gameObject.SetActive(false);
    
    }

    // Update is called once per frame
    void Update()
    {
        checkNhatKi();
    }
    void checkNhatKi()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 5, layerMask))
        {
            
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            viewText.gameObject.SetActive(true);
            if(viewText)
            {
                if (Input.GetKeyDown(KeyCode.E)) imgTorch.gameObject.SetActive(true);
            }
            
        }
        else
        {
            imgTorch.SetActive ( false) ;
            viewText.gameObject.SetActive(false) ;
        }
    }
}
