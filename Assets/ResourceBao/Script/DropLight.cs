using System.Collections;
using UnityEngine;

public class DropLight : MonoBehaviour
{
    public Light _light;
    [SerializeField] private float ActiveTime = 10f;
    [SerializeField] private AudioSource audioSource  ;
    [SerializeField] private AudioClip audioClip;

    void Start()
    {
        _light.enabled = true; // Đảm bảo đèn sáng khi bắt đầu
        StartCoroutine(Effectlight());
    }

    IEnumerator Effectlight()
    {
        while (true) // Lặp vô hạn
        {
            audioSource.PlayOneShot(audioClip);
            for (int i = 0; i < 4; i++) // Nháy 4 lần
            {
                _light.enabled = false;
               // Debug.Log("Light OFF"); // Kiểm tra trong console
                yield return new WaitForSeconds(0.1f); // Tắt trong 0.1s

                _light.enabled = true;
              //  Debug.Log("Light ON"); // Kiểm tra trong console
                yield return new WaitForSeconds(0.1f); // Bật trong 0.1s
            }

            _light.enabled = true; // Đảm bảo đèn sáng sau khi nháy xong
         //   Debug.Log("Light stays ON, waiting 10s...");

            yield return new WaitForSeconds(ActiveTime); // Đợi 10s trước khi lặp lại
        }
    }
}
