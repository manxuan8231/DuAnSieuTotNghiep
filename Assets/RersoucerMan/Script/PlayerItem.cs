using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerItem : MonoBehaviour
{
    public Transform position;// Vi tri item
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
         IncreaseItem(flashLight);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && keyCount1 > 0)
        {
          IncreaseItem(key1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && keyCount2 > 0)
        {
         
        }
    }
    public void IncreaseItem(GameObject item)
    {
        item.SetActive(!flashLight.activeSelf); // Kich hoat item
        rigBuilder.enabled = !rigBuilder.enabled;// Kich hoat rigBuilder
    }
    // Ham tang so luong item
    public void IncreaseFlashLightCount(int amount)
    {
        flashLightCount += amount;
    }

    public void IncreaseKey1Count(int amount)
    {
        keyCount1 += amount;
    }

    public void IncreaseKey2Count(int amount)
    {
        keyCount2 += amount;
    }
}
