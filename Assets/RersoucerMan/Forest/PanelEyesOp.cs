using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelEyesOp : MonoBehaviour
{
    private Image panelImage; // Image component của Panel
    public float fadeDuration = 2f; // Thời gian làm mờ dần

    void Start()
    {
        panelImage = GetComponent<Image>(); // Lấy Image của Panel

        // Đặt alpha ban đầu = 1 (Panel rõ ràng)
        Color startColor = panelImage.color;
        startColor.a = 1f;
        panelImage.color = startColor;

        // Bắt đầu hiệu ứng fade out
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = 1 - (time / fadeDuration); // Giảm alpha từ 1 về 0
            panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, alpha);
            yield return null;
        }

        // Đảm bảo alpha = 0 sau khi hoàn thành
        panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, 0f);
    }
}
