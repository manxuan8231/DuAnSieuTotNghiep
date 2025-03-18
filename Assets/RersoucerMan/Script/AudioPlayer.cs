using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip walkSound;
    public AudioClip runSound;
    public AudioClip jumpSound;
    void Start()
    {
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
}
