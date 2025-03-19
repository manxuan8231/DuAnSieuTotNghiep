using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance { get; private set; }

    public List<Item> items = new List<Item>();

    public Transform toorBar;
    public GameObject slotPrefab;

    private int maxItems = 3; // Giới hạn chỉ nhặt tối đa 3 item
    private void Awake()// Hàm Awake sẽ được gọi khi script được load vào bộ nhớ
    {
        if (instance != null || instance != this)
        {
            Destroy(instance);
        }      
        instance = this;
    }
    public void AddItem(Item item)
    {
        if (items.Count >= maxItems)// Nếu số lượng item trong list items lớn hơn hoặc bằng maxItems
        {
            return;// Thì thoát khỏi hàm
        }
        items.Add(item);// Thêm item vào list items
        DisplayInventory();// Hiển thị item
    }
    public void DisplayInventory()
    {
        foreach (Transform child in toorBar)// Duyệt qua các item trong toolbar
        {
            Destroy(child.gameObject);
        }
        foreach (Item item in items)// Duyệt qua các item trong list items
        {
           GameObject obj = Instantiate(slotPrefab, toorBar);
          // var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
           var itemImage = obj.transform.Find("ItemImage").GetComponent<Image>();

           // itemName.text = item.itemName;
            itemImage.sprite = item.image;

           
        }
    }
}
