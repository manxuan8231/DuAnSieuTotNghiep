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
       /* InventoryManager.Instance.Remove(item);
        Destroy(gameObject);*/
    }
    public void Use()
    {
        switch (item.type)
        {
            case ItemType.flashLight:
                FindAnyObjectByType<PlayerItem>().IncreaseFlashLightCount(item.value);
                //cộng điểm
                break;
            case ItemType.key:
                FindAnyObjectByType<PlayerItem>().IncreaseKey1Count(item.value);
                //cong diem
                break;
        }
    }
}
