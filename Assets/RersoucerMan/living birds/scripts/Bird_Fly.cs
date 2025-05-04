using UnityEngine;
using UnityEngine.Audio;

public class Bird_Fly : MonoBehaviour
{
    // Tham chiếu đến player
    public Transform player;

    // Bán kính phát hiện player
    public float detectionRadius = 5f;

    // Chiều cao bay lên
    public float flyHeight = 10f;

    // Tốc độ bay
    public float flySpeed = 5f;

    // Cờ kiểm tra nếu đã phát hiện player
    private bool hasSeenPlayer = false;

    // Vị trí bay đến
    private Vector3 targetPosition;
    public Animator animator;
    private AudioSource audioSource;

    public AudioClip song1;
    public AudioClip song2;
    public AudioClip flySound;

    private float timeLast = 0f;
    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject != null)
        {
            player = playerObject.transform;
        }
       
    }

    void Update()
    {
        // Nếu chưa thấy player, kiểm tra khoảng cách
        if (!hasSeenPlayer)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRadius)
            {
                audioSource.PlayOneShot(flySound);
                hasSeenPlayer = true;
                targetPosition = transform.position + Vector3.up * flyHeight;
            }
            if(Time.time >= timeLast + 10)
            {
                int randomSong = Random.Range(0, 10);
                if (randomSong == 0)
                {
                    audioSource.PlayOneShot(song1);
                }
                else if (randomSong == 9)
                {
                    audioSource.PlayOneShot(song2);
                }
                timeLast = Time.time;
            }           
        }

        // Nếu đã phát hiện player, bay lên trời
        if (hasSeenPlayer)
        {
            animator.SetBool("isFlying", true);
           
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, flySpeed * Time.deltaTime);
        }
    }
}
