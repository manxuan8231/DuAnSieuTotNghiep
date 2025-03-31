using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LinhHon : MonoBehaviour
{
    public GameObject NPCPanel; // Panel hiển thị hội thoại
    public TextMeshProUGUI NPCName; // Tên của NPC
    public TextMeshProUGUI NPCContent; // Nội dung hội thoại

    public string[] names; // Danh sách tên (ai đang nói)
    public string[] content; // Nội dung hội thoại

    private Coroutine coroutine;

    public BoxCollider boxCollider;
   private PlayerMovement playerMovement;
    private SliderUI sliderUI;
    void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        sliderUI = FindAnyObjectByType<SliderUI>();
        NPCPanel.SetActive(false);
        NPCName.text = "";
        NPCContent.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerMovement.enabled = false;
            playerMovement.animator.SetBool("isWalking", false);
            playerMovement.animator.SetBool("isRunning", false);
            sliderUI.runMana = false;// Không trừ mana khi không chạy
            sliderUI.walkMana = false; // Không trừ mana khi không đi bộ

            NPCPanel.SetActive(true);
            coroutine = StartCoroutine(ReadContent());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NPCPanel.SetActive(false);
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
        }
    }

    private IEnumerator ReadContent()
    {
        // Lặp qua từng câu thoại và tên
        for (int i = 0; i < content.Length; i++)
        {
            NPCContent.text = "";
            NPCName.text = names.Length > i ? names[i] : "Unknown"; // Hiển thị tên hoặc "Unknown" nếu không có tên

            foreach (var item in content[i])
            {
                NPCContent.text += item;
                yield return new WaitForSeconds(0.05f); // Tốc độ chạy chữ
            }
            yield return new WaitForSeconds(1f); // Thời gian ngừng giữa các câu
        }

        // Ẩn panel sau khi kết thúc hội thoại
        NPCPanel.SetActive(false);

        boxCollider.enabled = false;

        playerMovement.enabled = true;
        Destroy(gameObject,1f);
    }

    public void EndContent()
    {
        NPCPanel.SetActive(false);
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }
}
