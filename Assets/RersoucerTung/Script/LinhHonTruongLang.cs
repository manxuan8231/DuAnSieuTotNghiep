using UnityEngine;
using UnityEngine.AI;

public class LinhHonTruongLang : MonoBehaviour
{
    public Transform finalPoint;
    NavMeshAgent agent;
    public GameObject door;
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
        door.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
