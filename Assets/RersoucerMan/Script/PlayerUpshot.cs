using UnityEngine;

public class PlayerUpshot : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayerUpShot(Transform enemy)
    {
        if (enemy == null) return;

        // Xác định hướng đến enemy
        Vector3 directionToEnemy = enemy.position - transform.position;
        directionToEnemy.y = 0; // Giữ y = 0 để tránh nhân vật nghiêng

        // Gọi Flip để quay về phía enemy
        Flip(directionToEnemy);
    }

    private void Flip(Vector3 direction)
    {
        // Xoay nhân vật về phía enemy
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = newRotation;

        // Gọi animation
        animator.SetTrigger("HitDown");
    }
}
