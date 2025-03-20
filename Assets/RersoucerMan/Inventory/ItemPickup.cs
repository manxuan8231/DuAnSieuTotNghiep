using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    public void PickUp()
    {
        Destroy(gameObject);
        InventoryManager.instance.AddItem(item);// Thêm item vào list items
    }
    public void OnMouseDown()
    {
        PickUp();
        switch (item.type)
        {
            case ItemType.flashLight:
                FindAnyObjectByType<PlayerItem>().AddFlashLight(item.value);
                //cộng flashlight
                break;
            case ItemType.key:
                FindAnyObjectByType<PlayerItem>().AddKey1(item.value);
                //cộng key
                break;
        }      
        InventoryManager.instance.DisplayInventory();// Hiển thị item
    }
}

