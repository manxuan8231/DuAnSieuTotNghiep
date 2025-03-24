using UnityEngine;

public class ItemUIController : MonoBehaviour
{
    public Item item;

    public void SetItem(Item item)
    {
        this.item = item;
    }
    public void Remove()
    {
        InventoryManager.instance.Remove(item);
        Destroy(gameObject);

    }
    public void Use()
    {
        switch (item.type)
        {
            case ItemType.flashLight:
                FindAnyObjectByType<PlayerItem>().IncreaseFlashLightCount(item.value);
                
                break;
            case ItemType.key:
                FindAnyObjectByType<PlayerItem>().IncreaseFlashLightCount(item.value);              
                break;
        }
    }
}
