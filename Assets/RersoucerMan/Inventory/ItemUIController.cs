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
    /*public void Use()
    {
        switch(item.type)
        {
            case ItemType.bottle:
                FindAnyObjectByType<PlayerItem>().AddFlashLight(item.value);
                //cộng điểm
                break;
            case ItemType.glass:
                //trừ điểm
                break;
        }
    }*/
}
