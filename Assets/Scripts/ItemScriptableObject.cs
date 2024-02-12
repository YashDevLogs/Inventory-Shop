
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class ItemScriptableObject : ScriptableObject
{
    public ItemType ItemType;
    public string Name;
    public Sprite Icon;
    public string ItemDescription;
    public float BuyingPrice;
    public float SellingPrice;
    public ItemRarity Rarity;
    public float Quantity;
    public float Weight;
}
    