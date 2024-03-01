using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySO : ScriptableObject
{
    [SerializeField]
    private List<InventoryItem> inventoryItems;

     public void Initialize()
    {
        inventoryItems = new List<InventoryItem>();
        for (int i = 0; i < inventoryItems.Count; i++) 
        {
            inventoryItems.Add(InventoryItem.GetEmptyItem());
        }
    }

    public void AddItems(ItemScriptableObject item, int quantity)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty)
            {
                inventoryItems[i] = new InventoryItem
                {
                    item = item,
                    quantity = quantity
                };
            }
        }
    }

}

[Serializable]
public struct InventoryItem
{
    public int quantity;
    public ItemScriptableObject item;

    public bool IsEmpty => item == null; 

    public InventoryItem ChangeQuantity(int newQuantity)
    {
        return new InventoryItem
        {
            item = this.item,
            quantity = newQuantity
        };
    }

    public static InventoryItem GetEmptyItem()
         =>new InventoryItem
        {
        item = null,
        quantity = 0,
        };
}