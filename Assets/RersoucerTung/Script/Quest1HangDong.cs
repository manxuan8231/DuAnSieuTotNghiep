using UnityEngine;
using UnityEngine.Rendering;

public class Quest1HangDong : MonoBehaviour
{


    public int chooseWrongIndex = 0;
    public bool isChooseRight = false;
    public LayerMask TrueLayer;
    public LayerMask FalseLayer;
    public AudioSource audioSource;
    public AudioClip wrong1;
    public AudioClip wrong2;
    public EnemyQuestCave1 enemyQuestCave1;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        enemyQuestCave1 = FindAnyObjectByType<EnemyQuestCave1>();
        
    }
    void Update()
    {
        CheckItemPaper(); 
    }
    void CheckItemPaper()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 5, TrueLayer))
        {
            // Vẽ ray chỉ khi có va chạm
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);

            if (Input.GetKeyDown(KeyCode.E))
            {

                isChooseRight = true;
                TrueChoose();
            }                     
        }
        if (Physics.Raycast(transform.position, transform.forward, out var hit2, 5, FalseLayer))
        {
            Debug.DrawRay(transform.position, transform.forward * hit2.distance, Color.red);
            if (Input.GetKeyDown(KeyCode.E))
            {
                chooseWrongIndex++;
                if(chooseWrongIndex == 1 && chooseWrongIndex < 3)
                {
                    audioSource.PlayOneShot(wrong1);
                    Debug.Log("Cut");
                }
                if (chooseWrongIndex == 2 && chooseWrongIndex < 3)
                {
                    audioSource.PlayOneShot(wrong2);
                    Debug.Log("Cut");
                }
                if (chooseWrongIndex == 3)
                {
                    if (enemyQuestCave1 != null)
                    {
                        enemyQuestCave1.StartChasing(); // Kích hoạt Enemy đuổi theo Player
                    }
                }
            }
        }

    }

    void TrueChoose()
    {
        if (isChooseRight)
        {
            //sau khi xong nhiệm vụ này bùa ánh sáng sẽ được tăng lên 1

            Debug.Log("True");
        }
    }
  
}

