using TMPro;
using UnityEngine;

public class UIEvenNhatKyBao : MonoBehaviour
{
    public GameObject tichNhatKy;
    public GameObject tichBao;
    public TextMeshProUGUI textNhatKy;
    public TextMeshProUGUI textBao;
    public float countNhatKy;
    public float countBao;
    void Start()
    {
        tichNhatKy.SetActive(false);
        tichBao.SetActive(false);
        textNhatKy.text = $"Nhật ký: {countNhatKy}/1";
        textBao.text = $"Tờ Báo: {countBao}/1"; 
    }

    
    void Update()
    {
        if(countNhatKy > 0)
        {
            tichNhatKy.SetActive (true);
            textNhatKy.text = $"Nhật ký: {countNhatKy}/1";
        }
        if (countBao > 0)
        {
            tichBao .SetActive (true);
            textBao.text = $"Tờ Báo: {countBao}/1";
        }
    }
    public void GetNhatKy(float amount)
    {
        countNhatKy += amount;
    }
    public void GetBao(float amount)
    {
        countBao += amount;
    }
}
