using UnityEngine;

public class PeasantUpShot : MonoBehaviour
{
    public Transform enemy; // Gán enemy vào Inspector
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Attack");
            PlayerUpshot playerUpshot = other.GetComponent<PlayerUpshot>(); // Tìm trực tiếp trên Player

            if (playerUpshot != null)
            {
                playerUpshot.PlayerUpShot(enemy);
            }
            else
            {
                Debug.LogWarning("Không tìm thấy PlayerUpshot trên Player!");
            }
        }
    }

}
