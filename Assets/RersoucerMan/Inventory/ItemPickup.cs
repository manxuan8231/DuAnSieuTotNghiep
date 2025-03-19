using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;

    public void PickUp()
    {
        Destroy(gameObject);
        InventoryManager.instance.AddItem(item);
    }
    public void OnMouseDown()
    {
        PickUp();
        InventoryManager.instance.DisplayInventory();
    }

}

