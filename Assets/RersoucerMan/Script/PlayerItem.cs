using TMPro;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public GameObject flashLight;
    private float flashLightCount = 0f;
    public TextMeshProUGUI TextFlashLight;
    void Start()
    {
        flashLight.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && flashLightCount > 0)
        {          
            TextFlashLight.text = $"{flashLightCount}";
            flashLight.SetActive(true);
        }
    }
    public void AddFlashLight(float amount)
    {
        flashLightCount += amount;
        TextFlashLight.text = $"{flashLightCount}";      
    }
}
