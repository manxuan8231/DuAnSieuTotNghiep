using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerItem : MonoBehaviour
{
    //đèn pin
    public GameObject flashLight;
    private float flashLightCount = 0f;
  
    //key
    public GameObject key1;
    private float keyCount1 = 0f;

    public GameObject key2;
    private float keyCount2 = 0f;

    public RigBuilder rigBuilder;
    void Start()
    {
        flashLight.SetActive(false);
        key1.SetActive(false);
        key2.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && flashLightCount > 0)
        {                     
            flashLight.SetActive(!flashLight.activeSelf);
            rigBuilder.enabled = !rigBuilder.enabled;// tắt rigbuilder
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && keyCount1 > 0)
        {
            key1.SetActive(!key1.activeSelf);//bật tắt key1
            rigBuilder.enabled = !rigBuilder.enabled;//tắt rigbuilder
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && keyCount2 > 0)
        {
            key2.SetActive(!key2.activeSelf);//bật tắt key2
            rigBuilder.enabled = !rigBuilder.enabled;//tắt rigbuilder
        }
    }
    public void AddFlashLight(float amount)
    {
        flashLightCount += amount;       
    }

    public void AddKey1(float amount)
    {
        keyCount1 += amount;
    }
    public void AddKey2(float amount)
    {
        keyCount2 += amount;
    }
}
