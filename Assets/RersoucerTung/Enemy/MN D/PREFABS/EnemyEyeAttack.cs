using Unity.Cinemachine;
using UnityEngine;

public class EnemyEyeAttack : MonoBehaviour
{
    public float suckSpeed = 5f; // Tốc độ hút player
   
    public Transform enemyCenter; // Vị trí trung tâm của enemy

    private Animator animator;

    public CinemachineCamera targetCamera;

    private AudioSource audioSource;
    public AudioClip jumpScare;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
       animator = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Kiểm tra va chạm với player
        {
           targetCamera.Priority = 100;
            animator.SetTrigger("Attack");
            audioSource.PlayOneShot(jumpScare);
            PlayerLives playerLives = FindAnyObjectByType<PlayerLives>();
            playerLives.LoseLife();
        }
    }
   
    void Update()
    {
       
    }
}