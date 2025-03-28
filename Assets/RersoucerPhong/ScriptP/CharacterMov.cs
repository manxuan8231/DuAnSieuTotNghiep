using UnityEngine;
using UnityEngine.AI;

public class AICharacterMovement : MonoBehaviour
{
    public Transform[] waypoints; // Danh sách các điểm đến
    public float speed = 3.0f; // Tốc độ di chuyển
    public Animator animator; // Tham chiếu đến Animator
    public Transform idlePoint; // Điểm chỉ định để AI dừng lại

    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        MoveToNextWaypoint();
    }

    void Update()
    {
        if (waypoints.Length == 0) return;

        // Nếu AI đã đến điểm chỉ định (idlePoint), nó sẽ chuyển sang trạng thái idle
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (idlePoint != null && agent.destination == idlePoint.position)
            {
                agent.isStopped = true;
                animator.SetBool("IsMoving", false);
                animator.SetBool("idel", true);
                return; // Ngừng cập nhật nếu đã đến điểm idle
            }
            MoveToNextWaypoint();
        }

        // Kích hoạt animation di chuyển khi đang di chuyển
        bool isMoving = agent.velocity.magnitude > 0.1f;
        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("idel", !isMoving);
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.isStopped = false;
        agent.SetDestination(waypoints[currentWaypointIndex].position);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }
}