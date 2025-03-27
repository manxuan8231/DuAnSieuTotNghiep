using UnityEngine;

public class OpenCuatren : MonoBehaviour
{
    private PlayerItem playerItem;// Ke thua tu PlayerItem
    private Animator animator;// Animator cua cua
    private AudioSource audioSource;// Am thanh cua cua
    public AudioClip openDoorSound;// Am thanh mo
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        playerItem = FindAnyObjectByType<PlayerItem>();

    }


    private void Update()
    {
        
    }
    public void OnMouseDown()// Khi click chuot vao cua
        
    {
        
        if (playerItem.KeyCount1() > 0)
        {
            Debug.Log("Open Door");
            audioSource.PlayOneShot(openDoorSound);// Phat am thanh
          
            animator.SetTrigger("Open");// Mo cua
            playerItem.IncreaseKey1Count(-1);// Giam so luong key
            ItemUIController itemUI = FindAnyObjectByType<ItemUIController>();
            itemUI.Remove();// Xoa key khoi UI

        }
    }
}
