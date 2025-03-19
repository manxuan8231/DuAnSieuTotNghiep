using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flashLight;
    void Start()
    {
        flashLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashLight.SetActive(!flashLight.activeSelf);
        }
    }
}
