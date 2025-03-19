using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BossMap1 : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    private Animator Animator;
    


    public LayerMask whatIsGround, whatIsPlayer;

    //Patrol
    public Transform[] patrolPoints;
    private int currentPatrolPoints = -1;
    private bool isWaiting = false; // Tránh gọi coroutine liên tục
                                    //atack

    public bool isRage = false;
    //State
    public float sightRange, attackRange,hearRange;
    public bool playerInSightRange, playerInAttackRange,hearingPlayerSound;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        hearingPlayerSound =  Physics.CheckSphere(transform.position, hearRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange) Patrol();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange && !isRage) Attack();
        if (hearingPlayerSound) HearSoundChanged();


    }

    //Patrol
    IEnumerator WaitForMoveToPoint()
    {
        isWaiting = true; // Ngăn gọi lại coroutine nhiều lần
        agent.isStopped = true;
        agent.velocity = Vector3.zero; // Đảm bảo không bị giật do quán tính
        agent.ResetPath(); // Xóa đường đi hiện tại

        Animator.SetBool("isPatrol", false);
        Animator.SetBool("isIdle", true);

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

        Animator.SetBool("isPatrol", true);
        Animator.SetBool("isIdle", false);
        Animator.SetBool("isRun", false);
    }


    //Chase

    void ChasePlayer()
    {
        Animator.SetBool("isRun", true);
        Animator.SetBool("isPatrol", false);
        Animator.SetBool("isIdle", false);
        agent.SetDestination(target.position);

       
    }
    //attack
     void Attack()
    {
        isRage = true;
        Animator.SetTrigger("Rage");
    }

    //hearing
    void HearSoundChanged()
    {
        agent.SetDestination(target.position);
        Animator.SetBool("isRun", true);
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
}
