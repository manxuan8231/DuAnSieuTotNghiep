using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelEyes : MonoBehaviour
{
    private Image panelImage; // Image component của Panel
    public float fadeDuration = 2f; // Thời gian làm mờ dần

    void Start()
    {
        panelImage = GetComponent<Image>(); // Lấy Image của Panel

        // Đặt alpha ban đầu = 0 (Panel trong suốt)
        Color startColor = panelImage.color;
        startColor.a = 0;
        panelImage.color = startColor;

        // Bắt đầu hiệu ứng fade in
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float time = 0;
        float startAlpha = panelImage.color.a; // 0
        float endAlpha = 1; // Màu đậm

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeDuration);
            panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, alpha);
            yield return null;
        }

        panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, endAlpha);
    }
}
