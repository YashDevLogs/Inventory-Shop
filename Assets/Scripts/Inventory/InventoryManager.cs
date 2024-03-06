using Assets.Scripts.Inventory;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject SlotHolder;

    public List<SlotClass> items = new List<SlotClass>();

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
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().Icon;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = items[i].GetQuantity() + " ";
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
            }

        currentWeightText.text = "Weight : " + CurrentWeight + " / 50 kg Max".ToString();
    }

    public void AddItem(ItemScriptableObject item)
    {
        float totalWeight = item.Weight + CurrentWeight;
        if (totalWeight <= MaxWeight)
        {
            SlotClass slot = Contains(item);
            if (slot != null)
                slot.AddQuantity(1);
            else
            {
                items.Add(new SlotClass(item, 1));
                CurrentWeight += item.Weight;
                RefreshUI();
                itemBoughtPanel.SetActive(true);
            }
        }
        else
        {
            maxWeightReachedPanel.SetActive(true);
        }
    }


    public bool RemoveItem(ItemScriptableObject item)
    {   
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            if(temp.GetQuantity() > 1)
            temp.SubQuantity(1);
            else
            {
            SlotClass slotToRemove = new SlotClass();

                foreach (SlotClass slot in items)
                {
                    if (slot.GetItem() == item)
                    {
                        slotToRemove = slot;
                        break;
                    }
                }

                items.Remove(slotToRemove);
                CurrentWeight -= item.Weight;
            }

        }
        else
        {
            return false;
        }
       
        RefreshUI() ;
        return true;
    }

    private void ShowPanel(GameObject panelToShow)
    {
        inventoryPanel.SetActive(false);
        descriptionPanel.SetActive(false);

        panelToShow.SetActive(true);
    }

    public SlotClass Contains(ItemScriptableObject item)
    {
        foreach(SlotClass slot in items)
        {
            if(slot.GetItem() == item) return slot;
        }
        return null;
    }

   public int GetInventoryCount()
    {
        return items.Count;
    }
}