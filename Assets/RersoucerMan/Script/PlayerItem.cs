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
           
    }
    public void AddFlashLight(float amount)
    {
        flashLightCount += amount;
        TextFlashLight.text = $"{flashLightCount}";

        if (Input.GetKeyDown(KeyCode.Alpha1) && flashLightCount > 0)
        {
            flashLightCount -= amount;
            TextFlashLight.text = $"{flashLightCount}";
            flashLight.SetActive(true);
        }
    }
}
