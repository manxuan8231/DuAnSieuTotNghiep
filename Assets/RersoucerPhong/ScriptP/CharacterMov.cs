using UnityEngine;
using UnityEngine.AI;

public class AICharacterMovement : MonoBehaviour
{
    public Transform[] waypoints; // Danh sách các điểm đến
    public float speed = 3.0f; // Tốc độ di chuyển
    public Animator animator; // Tham chiếu đến Animator

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

        // Nếu AI đã đến điểm đích, chọn điểm tiếp theo
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextWaypoint();
        }

        // Kích hoạt animation chạy khi di chuyển
        animator.SetBool("isMoving", agent.velocity.magnitude > 0.1f);
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[currentWaypointIndex].position);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }
}