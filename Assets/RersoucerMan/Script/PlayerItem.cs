using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerItem : MonoBehaviour
{
    // Den pin
    public GameObject flashLight;
    private int flashLightCount = 0;

    // Key1 va Key2
    public GameObject key1;
    private int keyCount1 = 0;

    public GameObject key2;
    private int keyCount2 = 0;

    // RigBuilder
    public RigBuilder rigBuilder;

    void Start()
    {
        // Tat cac item luc dau
        flashLight.SetActive(false);
        key1.SetActive(false);
        key2.SetActive(false);
    }

    void Update()
    {
        // Kiem tra input va chuyen doi trang thai item
        if (Input.GetKeyDown(KeyCode.Alpha1) && flashLightCount > 0)
        {
            ToggleItem(flashLight);
        }
        

        if (Input.GetKeyDown(KeyCode.Alpha2) && keyCount1 > 0)
        {
            ToggleItem(key1);
        }
        else if(keyCount1 <= 0) 
        {
           key1.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && keyCount2 > 0)
        {
            ToggleItem(key2);
        }
       
    }
    // Ham chuyen doi trang thai item va RigBuilder
    private void ToggleItem(GameObject item)
    {
        bool isActive = !item.activeSelf;
        item.SetActive(isActive);
        rigBuilder.enabled = isActive;

        // Tat cac item khac de dam bao chi 1 item duoc kich hoat
        if (item != flashLight) flashLight.SetActive(false);
        if (item != key1) key1.SetActive(false);
        if (item != key2) key2.SetActive(false);
    }

    // Ham tang so luong item
    public void IncreaseFlashLightCount(int amount)
    {
        flashLightCount = Mathf.Max(0, flashLightCount + amount); 
    }

    public void IncreaseKey1Count(int amount)
    {
        keyCount1 = Mathf.Max(0, keyCount1 + amount);
    }
    public void IncreaseKey2Count(int amount)
    {
        keyCount2 = Mathf.Max(0, keyCount2 + amount);
    }

    public int KeyCount1()
    {
        return keyCount1;
    }
}
