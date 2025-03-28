using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Radio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip sosMors, sosMorse2, sosMorse3;
    public bool morse1, morse2, morse3 = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SosMorse()
    {
        morse1 = true;
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(sosMors);
    }
    IEnumerator SosMorse2()
    {
        morse1 = true;
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(sosMorse2);
    }
    IEnumerator SosMorse3()
    {
        morse1 = true;
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(sosMorse3);
    }
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            if(!morse1)
            {
                StartCoroutine(SosMorse());
            }
            if (morse1 && !morse2)
            {
                StartCoroutine(SosMorse2());
            }
            if (morse1 && morse2 && !morse3)
            {
                StartCoroutine(SosMorse3());
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Stop();
        }
    }
}
