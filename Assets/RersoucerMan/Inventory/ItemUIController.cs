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
        InventoryManager.instance.Remove(this.item);
        Destroy(this.gameObject);

    }
    public void Use()
    {
        switch (item.type)
        {
            case ItemType.flashLight:
                FindAnyObjectByType<PlayerItem>().IncreaseFlashLightCount(item.value);
                
                break;
            case ItemType.key:
                FindAnyObjectByType<PlayerItem>().IncreaseKey1Count(item.value);              
                break;
            case ItemType.glass:
                FindAnyObjectByType<PlayerItem>().IncreaseGlassCount(item.value);
                break;
        }
    }
}
