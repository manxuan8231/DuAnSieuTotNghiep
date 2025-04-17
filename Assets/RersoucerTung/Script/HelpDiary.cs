using UnityEngine;
using UnityEngine.UI;

public class HelpDiary : MonoBehaviour
{
    [SerializeField] private LayerMask layerSafebox;
    public RawImage imageSafebox;   
    private void Start()
    {   
        imageSafebox.gameObject.SetActive(false);
    }
    private void Update()
    {
        CheckItem();
    }
    public void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 5, layerSafebox))
        {
            // Vẽ ray chỉ khi có va chạm
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            imageSafebox.gameObject.SetActive(true);
        }
        else
        {
            imageSafebox.gameObject.SetActive(false);
        }
    }
}
