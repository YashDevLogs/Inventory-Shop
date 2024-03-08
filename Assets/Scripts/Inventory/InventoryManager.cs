using Assets.Scripts.Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] public ItemScriptableObject item { get; set; }

    [SerializeField] private GameObject SlotHolder;

    public List<SlotClass> items = new List<SlotClass>();

    [SerializeField] private CoinManager coinManager;


    [SerializeField] private GameObject itemSellPanel;
    [SerializeField] private GameObject menuButtons;
    [SerializeField] private Button SellButton;
    [SerializeField] private Button SellConfirmationButton;
    [SerializeField] private GameObject ShopPanel;

    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject shopDescriptionPanel;
    [SerializeField] private GameObject inventoryDescriptionPanel;
    [SerializeField] private GameObject maxWeightReachedPanel;
    [SerializeField] private GameObject itemBoughtPanel;
    [SerializeField] private GameObject SellConfirmationPanel;

    [SerializeField] private Button inventoryButton;
    [SerializeField] private ItemInfo itemDescriptionDisplay;
    [SerializeField] private SlotClass slotClass;

    [SerializeField] private Text currentWeightText;

    public float MaxWeight = 50;
    public float CurrentWeight;

    private GameObject[] slots;

    private void OnEnable()
    {
        EventService.Instance.OnItemSell.AddListener(SellItem);

    }

 
    private void OnDisable()
    {
        EventService.Instance.OnItemSell.RemoveListener(SellItem);
    }





    private void Start()
    {
        slots = new GameObject[SlotHolder.transform.childCount];
        for (int i = 0; i < SlotHolder.transform.childCount; i++)
            slots[i] = SlotHolder.transform.GetChild(i).gameObject;

        inventoryButton.onClick.AddListener(() => ShowPanel(inventoryPanel));

        RefreshUI();

        SellButton.onClick.AddListener(ShowSellConfirmationPanel);
        SellConfirmationButton.onClick.AddListener(InvokeOnItemBuy);
    }

    private void InvokeOnItemBuy()
    {
        EventService.Instance.OnItemSell.InvokeEvent();
    }

    private void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
            try
            {
                SlotClass slot = items[i];
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = slot.GetItem().Icon;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = slot.GetQuantity() + " ";
                // Add the respective scriptable item to the slot's button component
                Button slotButton = slots[i].GetComponent<Button>();
                slotButton.onClick.RemoveAllListeners(); // Clear existing listeners
                slotButton.onClick.AddListener(() => ShowDescriptionPanel(slot.GetItem())); // Add new listener
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
            }

        currentWeightText.text = "Weight : " + CurrentWeight + " / 50 kg Max".ToString();
    }


    public void ShowSellConfirmationPanel()
    {
        SellConfirmationPanel.SetActive(true);
    }
    private void ShowDescriptionPanel(ItemScriptableObject item)
    {
        itemSellPanel.SetActive(false);
        ShopPanel.SetActive(false);
        menuButtons.SetActive(false);


        // Show the description panel with the selected item information
        inventoryDescriptionPanel.SetActive(true);
        Debug.Log("inventoryDescriptionPanel enabled from Inventory manager");
        /* itemInfo.DisplayItemDescription(item);
         Debug.Log("Info From Inventroy manager passed");*/

        ItemInfo inventoryDescriptionDisplay = inventoryDescriptionPanel.GetComponent<ItemInfo>();
        inventoryDescriptionDisplay.DisplayItemDescription(item);
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
                StartCoroutine(HideBoughtPanel());
            }
        }
        else
        {
            maxWeightReachedPanel.SetActive(true);
        }
    }

    IEnumerator HideBoughtPanel()
    {
        yield return new WaitForSeconds(1f);
        itemBoughtPanel.SetActive(false);
    }

    public bool RemoveItem(ItemScriptableObject item)
    {
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            if (temp.GetQuantity() > 1)
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

        RefreshUI();
        return true;
    }

    private void ShowPanel(GameObject panelToShow)
    {
        inventoryPanel.SetActive(false);
        shopDescriptionPanel.SetActive(false);

        panelToShow.SetActive(true);
    }

    public SlotClass Contains(ItemScriptableObject item)
    {
        foreach (SlotClass slot in items)
        {
            if (slot.GetItem() == item) return slot;
        }
        return null;
    }

    private void SellItem()
    {
        item = itemDescriptionDisplay.item;
        coinManager.AddCoins(item.SellingPrice);
        RemoveItem(item);
        SellConfirmationPanel.SetActive(false);
    }
}
