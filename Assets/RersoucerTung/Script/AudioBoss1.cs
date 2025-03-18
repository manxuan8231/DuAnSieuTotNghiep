using UnityEngine;

public class AudioBoss1 : MonoBehaviour
{
   public AudioSource audioSource;
   public AudioClip audioRage;
   public AudioClip audioPatrol;
    public AudioClip audioRun;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayAudioRage()
    {
        
        audioSource.PlayOneShot(audioRage);
    }
    public void EndAudioRage()
    {
        audioSource.Stop();
    }
    public void PlayAudioPatrol()
    {
        audioSource.PlayOneShot(audioPatrol);
    }
    public void PlayAudioRun()
    {
        audioSource.PlayOneShot(audioRun);
    }
    public void EndAudioPatrol()
    {
        audioSource.Stop();
    }
    public void EndAudioRun()
    {
        audioSource.Stop();
    }
    
}


