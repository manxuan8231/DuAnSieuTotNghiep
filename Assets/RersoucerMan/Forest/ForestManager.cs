using UnityEngine;

public class ForestManager : MonoBehaviour
{
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        playerMovement.enabled = false;
        Invoke("OnPlayerMovement", 5f);//chờ 2f r chạy hàm onPlayer
    }

    
    void Update()
    {
        
    }
    private void OnPlayerMovement()//player di chuyenr
    {
        playerMovement.enabled = true;
    }
}
