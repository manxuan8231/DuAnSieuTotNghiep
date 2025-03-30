using UnityEngine;

public class PeasantUpShot : MonoBehaviour
{
    public Transform enemy; // Gán enemy vào Inspector
    private Animator animator;
    private int countAttack = 1;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
        }
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
}
