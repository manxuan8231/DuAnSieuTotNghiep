using UnityEngine;
using UnityEngine.AI;

public class EnemyQuestCave1 : MonoBehaviour
{
    public Transform player;  // Tham chiếu đến Player
    private NavMeshAgent agent;
    private bool isChasing = false; // Enemy có đang đuổi theo Player không?

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isChasing && player != null)
        {
            agent.speed = 10;
            agent.SetDestination(player.position); // Cập nhật vị trí Player liên tục
            float distance = Vector3.Distance(transform.position, player.position);
            Debug.Log("Enemy đang đuổi theo Player! Khoảng cách: " + distance);
        }
    }

    public void StartChasing()
    {
        isChasing = true;
        Debug.Log("Enemy bắt đầu đuổi theo Player!");
    }
}
