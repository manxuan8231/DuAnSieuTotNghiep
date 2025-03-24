using TMPro;
using UnityEngine;

public class HomeDoor : MonoBehaviour
{
   
    private PlayerItem playerItem;// Ke thua tu PlayerItem
    private Animator animator;// Animator cua cua
    private AudioSource audioSource;// Am thanh cua cua
    public AudioClip openDoorSound;// Am thanh mo
    public TextMeshProUGUI E;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        playerItem = FindAnyObjectByType<PlayerItem>();
    }

   
    void Update()
    {
        
    }
    public void OnMouseDown()// Khi click chuot vao cua
    {
        if(playerItem.KeyCount1() > 0)
        {
            Debug.Log("Open Door");
            audioSource.PlayOneShot(openDoorSound);// Phat am thanh
            animator.SetBool("isOpen", true);// Mo cua
            playerItem.IncreaseKey1Count(-1);// Giam so luong key
            ItemUIController item = FindAnyObjectByType<ItemUIController>();
            item.Remove();// Xoa key khoi UI
        }     
    }
   
}

