using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommenEvenGuong : MonoBehaviour
{
    //text hoi thoai
    public TextMeshProUGUI textHoiThoaiChamGuong;
    public TextMeshProUGUI textNhiemVuTimManhGiay;
    public bool isActicve = false;
    public bool isClick = false;

    //Nhiem vu
    public List<int> dungThuTu = new List<int>() { 1, 2, 3 };
    private List<int> hienTai = new List<int>();
    private List<Guong> guongDaBam = new List<Guong>();

    public GameObject vatPhamXuatHien;

    private AudioSource audioSource;
    public AudioClip audioClipClickE;
    public AudioClip audioClipRight;
    public AudioClip audioClipLoi;

    //text 
    public TextMeshProUGUI textCanhBao;

    void Start()
    {
        textHoiThoaiChamGuong.enabled = false;
        textNhiemVuTimManhGiay.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        
    }

    public void KiemTraGuong(Guong guong)
    {
        int id = guong.id;
        if (hienTai.Contains(id)) return; // tránh bấm trùng
        
        hienTai.Add(id);
        guongDaBam.Add(guong);

        Debug.Log("Đã bấm gương ID: " + id);
        audioSource.PlayOneShot(audioClipClickE);
        if (hienTai.Count == dungThuTu.Count)
        {
            bool allCorrect = true;

            for (int i = 0; i < dungThuTu.Count; i++)
            {
                if (hienTai[i] != dungThuTu[i])
                {
                    allCorrect = false;
                    break;
                }
            }

            if (allCorrect)
            {
                Debug.Log(" Đã giải mã đúng hết gương!");
                StartCoroutine(TextColdownDung(3));
                audioSource.PlayOneShot(audioClipRight);
                isClick = false;//đẻ ko bấm E đc nữa
            }
            else
            {
                Debug.Log("Sai thứ tự!");
                StartCoroutine(TextColdownSai(3));
                audioSource.PlayOneShot(audioClipLoi);
                StartCoroutine(ResetGuongSauDelay(1f));
            }
        }
    }

    private IEnumerator ResetGuongSauDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Đã reset lại");
        hienTai.Clear();
        guongDaBam.Clear();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Glass") && !isActicve)
        {
            StartCoroutine(ColdownHoiThoai(3));
        }
    }
    public IEnumerator ColdownHoiThoai(float amout)
    {
        textHoiThoaiChamGuong.enabled = true;
        textHoiThoaiChamGuong.text = "Có vẻ như chiếc gương này có thể tương tác được";
        yield return new WaitForSeconds(amout);
        isClick = true;
        isActicve = true;
        textHoiThoaiChamGuong.text = "Có vẻ như đây là một cơ quan nào đó...";
        yield return new WaitForSeconds(amout);
        textHoiThoaiChamGuong.text = "Tôi cần phải tìm manh mối xung quanh";
        yield return new WaitForSeconds(amout);
        textHoiThoaiChamGuong.enabled =false;
        textNhiemVuTimManhGiay.enabled = true;
        textNhiemVuTimManhGiay.text = "Nhiệm vụ: Kích hoặc gương theo đúng thứ tự";
        yield return new WaitForSeconds(amout);
        textNhiemVuTimManhGiay.text = "Gợi ý tìm 3 mảnh giấy chứa mật mã.";
        yield return new WaitForSeconds(amout);
        textNhiemVuTimManhGiay.enabled = false;
       
    }

    public IEnumerator TextColdownDung(float amout)
    {
        textCanhBao.enabled = true;
        textCanhBao.color = Color.green;
        textCanhBao.text = $"Đã giải mã đúng hết gương";
        yield return new WaitForSeconds(amout);
        textCanhBao.enabled = false;
       
    }
    public IEnumerator TextColdownSai(float amout)
    {
        textCanhBao.enabled = true;
        textCanhBao.color = Color.red;
        textCanhBao.text = $"Sai thứ tự!";
        yield return new WaitForSeconds(amout);
        textCanhBao.enabled = false;

    }
}
