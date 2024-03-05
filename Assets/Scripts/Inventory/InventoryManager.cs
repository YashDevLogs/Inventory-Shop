using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject SlotHolder;

    private List<ItemScriptableObject> items = new List<ItemScriptableObject>();

    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject descriptionPanel;
    [SerializeField] private GameObject maxWeightReachedPanel;
    [SerializeField] private GameObject itemBoughtPanel;


    [SerializeField] private Button inventoryButton;
    [SerializeField] private ItemInfo itemInfo;

    [SerializeField] private Text currentWeightText;

    public float MaxWeight = 50;
    public float CurrentWeight;

    private GameObject[] slots;  

    private void Start()
    {
        slots = new GameObject[SlotHolder.transform.childCount];
        for (int i = 0; i < SlotHolder.transform.childCount; i++)
            slots[i] = SlotHolder.transform.GetChild(i).gameObject;

        inventoryButton.onClick.AddListener(() => ShowPanel(inventoryPanel));


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

        currentWeightText.text = "Weight : " + CurrentWeight + " / 50 kg Max".ToString();
    }

    public void AddItem(ItemScriptableObject item)
    {
      item = itemInfo.item;
      float  totalWeight = item.Weight + CurrentWeight;
        if (totalWeight <= MaxWeight)
         {
            items.Add(item);
            CurrentWeight += item.Weight;
            RefreshUI();
            itemBoughtPanel.SetActive(true);
        }
        else 
        {    
            maxWeightReachedPanel.SetActive(true);           
        }  
    }
    public void RemoveItem(ItemScriptableObject item)
    {
        items.Remove(item);
        CurrentWeight -= item.Weight;
    }
    private void ShowPanel(GameObject panelToShow)
    {
        inventoryPanel.SetActive(false);
        descriptionPanel.SetActive(false);

        panelToShow.SetActive(true);
    }
}
