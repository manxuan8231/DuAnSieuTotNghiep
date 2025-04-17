using UnityEngine;

public class DestroyFixLag : MonoBehaviour
{
    public GameObject destroy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Destroy(destroy);
        }
    }
}
