using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite image;
}
