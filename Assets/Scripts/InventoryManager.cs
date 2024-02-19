using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject SlotHolder;

    public List<ItemScriptableObject> items = new List<ItemScriptableObject>();

    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject descriptionPanel;


    [SerializeField] private Button InventoryButton;

    private float MaxWeight = 50 ;
    private float CurrentWeight;


    private GameObject[] slots;  

    private void Start()
    {
        slots = new GameObject[SlotHolder.transform.childCount];
        for (int i = 0; i < SlotHolder.transform.childCount; i++)
            slots[i] = SlotHolder.transform.GetChild(i).gameObject;

        InventoryButton.onClick.AddListener(() => ShowPanel(inventoryPanel));

        RefreshUI();


    }

    private void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].Icon;
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
    }

    public void AddItem(ItemScriptableObject item)
    {
        if(CurrentWeight <= MaxWeight) 
        { 
            items.Add(item);
            CurrentWeight += item.Weight;
            RefreshUI();
        }
        else
        {
            Debug.Log("maximum weight occupied");
        }
    }

    public void RemoveItem(ItemScriptableObject item)
    {
        items.Remove(item);
        CurrentWeight -= item.Weight;
    }

    public void ShowPanel(GameObject panelToShow)
    {
        inventoryPanel.SetActive(false);
        descriptionPanel.SetActive(false);

        panelToShow.SetActive(true);
    }
}
