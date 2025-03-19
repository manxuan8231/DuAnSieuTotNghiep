using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flashLight;//đèn pin
    public AudioSource audioSource;//âm thanh
    public AudioClip flashLightSound;//âm thanh khi bật đèn
    void Start()
    {
        flashLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            audioSource.PlayOneShot(flashLightSound);
            flashLight.SetActive(!flashLight.activeSelf);//bật tắt đèn
        }
    }
}
