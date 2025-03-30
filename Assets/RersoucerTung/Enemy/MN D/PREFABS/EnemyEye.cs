using UnityEngine;
using UnityEngine.AI;

public class EnemyEye : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    // Khoảng cách để enemy bắt đầu di chuyển
    public float detectionDistance = 20f;

    // Góc tối đa để phát hiện player nhìn thẳng
    public float detectionAngle = 30f;

    private Animator animator;

    public BoxCollider boxCollider;
    private void Start()
    {
        boxCollider.enabled = false;    
        animator = GetComponent<Animator>();
        // Tìm player bằng tag "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
       
    }
    void Update()
    {
        if (IsPlayerLookingAtEnemy())
        {
            // Enemy di chuyển về phía player
            agent.isStopped = false;
            agent.SetDestination(player.position);
            animator.SetBool("Walk",true);
            boxCollider.enabled = true;
        }
        else
        {
            // Dừng lại nếu player không nhìn thẳng
            agent.isStopped = true;
            animator.SetBool("Walk",false);
            boxCollider.enabled = false;
        }
    }

    // Hàm kiểm tra nếu player đang nhìn thẳng vào enemy
    bool IsPlayerLookingAtEnemy()
    {
        // Vector từ player tới enemy
        Vector3 directionToEnemy = transform.position - player.position;
        float distance = directionToEnemy.magnitude;

        // Kiểm tra nếu enemy trong khoảng cách cho phép
        if (distance > detectionDistance)
        {
            return false;
        }

        // Tính góc giữa hướng nhìn của player và hướng tới enemy
        float angle = Vector3.Angle(player.forward, directionToEnemy);

        // Trả về true nếu góc nhỏ hơn hoặc bằng detectionAngle
        return angle <= detectionAngle;
    }
}
