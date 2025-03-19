using UnityEngine;

public enum ItemType
{
    bottle,//dùng để cộng điểm
    glass//dùng để trừ điểm
}
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite image;
    public ItemType type;
}
