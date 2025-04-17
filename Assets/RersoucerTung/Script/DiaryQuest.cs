using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class DiaryQuest : MonoBehaviour
{
    public LayerMask DiaryMask;
    public TextMeshProUGUI textContentDiary;
    public CinemachineCamera cameraPlayerDiary;
    public CinemachineCamera cameraDiary;
    public GameObject diary;
    public LinhHonTruongLang linhHonTruongLang;
    public BoxCollider boxCollider;
    //Diary
    void Start()
    {
        textContentDiary.gameObject.SetActive(false);
        linhHonTruongLang = FindAnyObjectByType<LinhHonTruongLang>();
        boxCollider = GameObject.Find("DiaryQuest3Forest").GetComponent<BoxCollider>();
        boxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDiary();
    }
    void CheckDiary()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 5, DiaryMask))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(ChangeCameraDiary());
            }
        }
    }
    //routine Diary
    IEnumerator ChangeCameraDiary()
    {
        cameraDiary.Priority = 20;
        cameraPlayerDiary.Priority = 0;
        yield return new WaitForSecondsRealtime(1f);
        textContentDiary.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        cameraDiary.Priority = 0;
        cameraPlayerDiary.Priority = 10;
        yield return new WaitForSecondsRealtime(2f);
        textContentDiary.gameObject.SetActive(false);
        diary.SetActive(false);
        linhHonTruongLang.Item();
    }
}
