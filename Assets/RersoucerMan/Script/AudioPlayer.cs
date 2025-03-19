using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip walkSound;
    public AudioClip runSound;
    public AudioClip jumpSound;

    public AudioSource audioSource2;

    private SliderUI sliderUI;
    void Start()
    {
        sliderUI = FindAnyObjectByType<SliderUI>();
        audioSource = GetComponent<AudioSource>();
    } 
    public void Walk()
    {
       audioSource.PlayOneShot(walkSound);
    }
    public void Run()
    {
        audioSource.PlayOneShot(runSound);
    }
    public void Jump()
    {
        audioSource.PlayOneShot(jumpSound);
    }
    private void Update()
    {
        if (sliderUI.CurrentMana() <= 50)
        {
            audioSource2.enabled = true;
        }
        else
        {
            audioSource2.enabled = false;
        }
    }
}
