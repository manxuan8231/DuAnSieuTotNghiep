using UnityEngine;

public class PeasantUpShot : MonoBehaviour
{
    public Transform enemy; // Gán enemy vào Inspector
    private Animator animator;
    private int countAttack = 1;
    private AudioSource audiosource;
    public AudioClip audioClip;
    private void Start()
    {
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }
   
    public void OnMouseEnter()
    {
        if (countAttack > 0)
        {
            animator.SetTrigger("Attack");
            PlayerUpshot playerUpshot = FindAnyObjectByType<PlayerUpshot>();
            playerUpshot.PlayerUpShot(enemy.transform);
            countAttack -= 1;
        }
    }
    public void AudioAttack()
    {
       audiosource.PlayOneShot(audioClip);
    }
}
