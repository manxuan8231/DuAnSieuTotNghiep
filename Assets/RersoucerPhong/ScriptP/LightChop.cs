using System.Collections;
using UnityEngine;

public class LightChop : MonoBehaviour
{
    public Light _light;
    public AudioSource audioSource; // Thêm AudioSource
    public AudioClip flashSound; // Âm thanh khi chớp

    private float nextFlashTime = 0f; // Thời điểm cho phép nháy tiếp theo

    void Start()
    {
        _light.enabled = true; // Đèn luôn sáng
    }

    void Update()
    {
        // Nếu đã đủ 10s kể từ lần nháy trước và có 1% cơ hội xảy ra
        if (Time.time >= nextFlashTime && Random.Range(0, 100) < 1)
        {
            StartCoroutine(FlashEffect());
            nextFlashTime = Time.time + 50f; // Cập nhật thời gian nháy tiếp theo
        }
    }

    IEnumerator FlashEffect()
    {
        for (int i = 0; i < 3; i++) // Nháy 3 lần
        {
            _light.enabled = false;
            PlayFlashSound(); // Gọi âm thanh khi đèn tắt
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f)); // Tắt trong khoảng 0.1 - 0.3s

            _light.enabled = true;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f)); // Bật lại trong khoảng 0.1 - 0.3s
        }
    }

    void PlayFlashSound()
    {
        if (audioSource != null && flashSound != null)
        {
            audioSource.PlayOneShot(flashSound); // Phát âm thanh chớp
        }
    }
}
