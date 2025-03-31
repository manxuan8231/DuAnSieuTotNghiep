using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class LinhHonMovement : MonoBehaviour
{
    public NavMeshAgent agent;
   

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrol
    public Transform[] patrolPoints;
    private int currentPatrolPoints = -1;
    private bool isWaiting = false; // Tránh gọi coroutine liên tục
                                    //atack

    public bool isRage = false;
    //State
    public float sightRange, attackRange, hearRange;
    public bool playerInSightRange, playerInAttackRange, hearingPlayerSound;
    public bool isWalk;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
     
    }

    void Update()
    {
        if (isWalk) {
            hearingPlayerSound = Physics.CheckSphere(transform.position, hearRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            if (!playerInSightRange && !playerInAttackRange) Patrol();

        }

    }

    //Patrol
    IEnumerator WaitForMoveToPoint()
    {
        isWaiting = true; // Ngăn gọi lại coroutine nhiều lần
        agent.isStopped = true;
        agent.velocity = Vector3.zero; // Đảm bảo không bị giật do quán tính
        agent.ResetPath(); // Xóa đường đi hiện tại

    

        yield return new WaitForSeconds(5f);

        agent.isStopped = false;
        MoveToRandomWaypoint();
        isWaiting = false;
    }
    void Patrol()
    {
        if (patrolPoints.Length == 0 || isWaiting) return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            StartCoroutine(WaitForMoveToPoint());
        }
    }
    void MoveToRandomWaypoint()
    {
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, patrolPoints.Length);
        }
        while (randomIndex == currentPatrolPoints); // Đảm bảo không lặp lại điểm cũ

        currentPatrolPoints = randomIndex;
        agent.SetDestination(patrolPoints[currentPatrolPoints].position);

       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, hearRange);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            isWalk = false;
        }
    }
}
