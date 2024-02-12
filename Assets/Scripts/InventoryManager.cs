using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemScriptableObject> items = new List<ItemScriptableObject>();

    [SerializeField] private GameObject SlotHolder;

    public ItemScriptableObject ItemsToAdd;
    public ItemScriptableObject ItemsToRemove;

    private GameObject[] Slots;
    private void Start()
    {

    }

    public void Add(ItemScriptableObject item) => items.Add(item);
    public void Remove(ItemScriptableObject item) => items.Remove(item); 

}
