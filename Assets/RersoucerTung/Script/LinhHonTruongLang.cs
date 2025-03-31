using UnityEngine;
using UnityEngine.AI;

public class LinhHonTruongLang : MonoBehaviour
{
    public Transform finalPoint;
    NavMeshAgent agent;
    public GameObject door;
    public int ItemCollect = 0;
    public bool playerInZone = false;

    public BoxCollider boxCollider;
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       
     

    }

    // Update is called once per frame
    void Update()
    {
        if(ItemCollect < 3)
        {
            door.SetActive(false);
        }
        if(ItemCollect >= 3 && playerInZone)
        {
            boxCollider.enabled = true;
            door.SetActive(true);
            agent.SetDestination(finalPoint.position);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInZone = true;
            agent.isStopped = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInZone = false;
            agent.isStopped = true;
        }
    }
    public void Item()
    {
        ItemCollect++;
        Debug.Log(ItemCollect);
    }
}
