using System.Collections;
using TMPro;
using UnityEngine;

public class Radio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip sosMors;
    public bool morse1;
    private BoxCollider boxCollider;
    private bool playerInside = false;
    public TextMeshProUGUI textMorse1;
    public string[] content1;
    public GameObject model;
    public AudioClip scaredSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
        textMorse1.gameObject.SetActive(false);
        model.SetActive(false);
    }

    void Update()
    {
        if (playerInside && !audioSource.isPlaying) 
        {
            PlayMorse();
        }
    }
      


    public void OnBox()
    {
        boxCollider.enabled = true;
    }

    void PlayMorse()
    {
        if (!morse1)
        {
            StartCoroutine(SosMorse());
            
        }
       
    }

    IEnumerator SosMorse()
    {
        audioSource.clip = sosMors;
        audioSource.loop = true;
        audioSource.Play();
        yield return new WaitForSeconds(2f);    
        morse1 = true;
        StartCoroutine(textMorse1Routie());
        yield return new WaitForSeconds(18f);
        audioSource.Stop();
        StopCoroutine(textMorse1Routie());
        textMorse1.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        audioSource.PlayOneShot(scaredSound);
        model.SetActive(true);
    }

  

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            PlayMorse();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            audioSource.Stop();
            textMorse1.gameObject.SetActive(false);
        }
    }
    IEnumerator textMorse1Routie()
    {
        textMorse1.gameObject.SetActive(true);
        for (int i = 0; i < content1.Length; i++)
        {
            textMorse1.text = "";

            foreach (var item in content1[i])
            {
                textMorse1.text += item;
                yield return new WaitForSecondsRealtime(0.1f); // Dùng WaitForSecondsRealtime để chạy dù Time.timeScale = 0
            }
            yield return new WaitForSecondsRealtime(3f); // Tạm dừng giữa các câu
        }
    }
}

