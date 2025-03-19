using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    public Slider sliderMana;
    private float currentMana = 0;
    private float maxMana = 100f;
    private float regenTime = 0;

    public bool runMana = false;
    void Start()
    {
        currentMana = maxMana;
        sliderMana.maxValue = currentMana;
    }

    void Update()
    {
        if(runMana)
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
    }
    public float CurrentMana()
    { 
       return currentMana; 
    }
}
