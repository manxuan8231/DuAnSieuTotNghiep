using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Transform[] patrolPoints;
    public float visionRange = 10f;
    public float visionAngle = 60f;
    public float lostTime = 3f;
    public float waitTime = 5f;

    private NavMeshAgent agent;
    private int patrolIndex = 0;
    private float lostTimer = 0f;
    private bool isChasing = false;
    private bool isWaiting = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToNextPatrolPoint();
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            isChasing = true;
            agent.isStopped = false;
            agent.SetDestination(player.position);
            lostTimer = 0f;
        }
        else if (isChasing)
        {
            lostTimer += Time.deltaTime;
            if (lostTimer >= lostTime)
            {
                isChasing = false;
                GoToNextPatrolPoint();
            }
        }
        else if (!isWaiting && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            StartCoroutine(WaitAtPatrolPoint());
        }
    }

    IEnumerator WaitAtPatrolPoint()
    {
        isWaiting = true;
        agent.isStopped = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
        agent.isStopped = false;
        GoToNextPatrolPoint();
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;
        agent.SetDestination(patrolPoints[patrolIndex].position);
        patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
    }

    bool CanSeePlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
        return distanceToPlayer < visionRange && angleToPlayer < visionAngle / 2 &&
               !Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer);
    }
}
