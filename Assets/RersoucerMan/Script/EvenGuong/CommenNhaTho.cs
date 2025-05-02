using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class CommenNhaTho : MonoBehaviour
{
    public GameObject text;
    public bool isActive = false;
    public TextMeshProUGUI textHoiThoaiLucVao;
    public CinemachineCamera nhaThoCamera;

    public TextMeshProUGUI textNhiemVuTimHieuXungQuanh;
    void Start()
    {
       
        text.SetActive(false);
        textNhiemVuTimHieuXungQuanh.enabled = false;
    }

   
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isActive == false)
        {
            Debug.Log("Vao day");
            StartCoroutine(WaitForSeconds(2f));
        }
    }
    IEnumerator WaitForSeconds(float time)
    {
        nhaThoCamera.Priority = 100;
        isActive = true;
        text.SetActive(true);
        textHoiThoaiLucVao.text = " Ở đây lại có một cái nhà thơ ư?";
        yield return new WaitForSeconds(time);
        textHoiThoaiLucVao.text = " Thật kì lạ?";
        yield return new WaitForSeconds(time);
        nhaThoCamera.Priority = 0;
        textHoiThoaiLucVao.text = " Trong nó thật rùng rợn.";
        yield return new WaitForSeconds(time);
        textNhiemVuTimHieuXungQuanh.enabled = true;
        textNhiemVuTimHieuXungQuanh.text = "Nhiệm vụ: Tìm hiểu bên trong nhà thờ.";
        yield return new WaitForSeconds(time);
        text.SetActive(false);
        
    }
}
