using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    public Slider sliderMana;
    private float currentMana = 0;
    public float maxMana = 100f;
    private float regenTime = 0;

    public bool runMana = false;
    public bool walkMana = false;

    public GameObject canvasSliderMana;

   
    void Start()
    {
        canvasSliderMana.SetActive(false);
        currentMana = maxMana;
        sliderMana.maxValue = currentMana;

      
    }

    void Update()
    {
        if(runMana && walkMana)// Trừ mana khi chạy
        {
            currentMana -= 15 * Time.deltaTime;           
            currentMana = Mathf.Clamp(currentMana, 0, maxMana);
            sliderMana.value = currentMana;
            regenTime = 0;
        }
        else
        {
            if (regenTime >= 1)
            {
                currentMana += 10 * Time.deltaTime;
                currentMana = Mathf.Clamp(currentMana, 0, maxMana);
                sliderMana.value = currentMana;
            }
            else
            {
                regenTime += Time.deltaTime;
            }
        }
        //mana be hon 100 thi hien thanh mana
        if(currentMana < 100)
        {
            canvasSliderMana.SetActive(true);
        }
        else
        {
            canvasSliderMana.SetActive(false);
        }
    }
    public float CurrentMana()
    { 
       return currentMana; 
    }
}
