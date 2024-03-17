using Assets.Scripts.Inventory;
using ServiceLocator.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{

    private GameObject slotPrefab;
    private Transform slotContainer;


    [SerializeField]private ItemScriptableObject item;

    public List<SlotClass> items = new List<SlotClass>();

    [SerializeField] private CoinManager coinManager;

    private GameObject itemSellPanel;
    private GameObject menuButtons;
    [SerializeField] private Button SellButton;
    [SerializeField]private Button SellConfirmationButton;
    private GameObject ShopPanel;

    private GameObject inventoryPanel;
    private GameObject shopDescriptionPanel;
    private GameObject inventoryDescriptionPanel;
    private GameObject maxWeightReachedPanel;
    private GameObject itemBoughtPanel;
    [SerializeField] private GameObject SellConfirmationPanel;

    private Button inventoryButton;

    private ItemView itemDescriptionDisplay;
    [SerializeField] private SlotClass slotClass;

    private Text currentWeightText;

    private List<GameObject> slots = new List<GameObject>();

    public float MaxWeight = 50;
    public float CurrentWeight;
    private void OnEnable()
    {
        EventService.Instance.OnItemSell.AddListener(SellItem);
    }

    private void OnDisable()
    {
        EventService.Instance.OnItemSell.RemoveListener(SellItem);
    }


    public InventoryManager(Button SellButton, Button SellConfirmationButton, GameObject inventoryPanel, GameObject shopDescriptionPanel, Button inventoryButton, Text currentWeightText, GameObject slotPrefab, Transform slotContainer, GameObject itemBoughtPanel, GameObject maxWeightReachedPanel, GameObject shopPanel, GameObject inventoryDescriptionPanel, GameObject menuButtons, GameObject itemSellPanel)
    {
        // Initialize other variables
        this.SellButton = SellButton;
        this.SellConfirmationButton = SellConfirmationButton;
        this.inventoryPanel = inventoryPanel;
        this.shopDescriptionPanel = shopDescriptionPanel;
        this.inventoryButton = inventoryButton;
        this.currentWeightText = currentWeightText;
        this.slotPrefab = slotPrefab;
        this.slotContainer = slotContainer;
        this.itemBoughtPanel = itemBoughtPanel;
        this.maxWeightReachedPanel = maxWeightReachedPanel;
        this.ShopPanel = shopPanel;
        this.inventoryDescriptionPanel = inventoryDescriptionPanel;
        this.menuButtons = menuButtons;
        this.itemSellPanel = itemSellPanel;

        InstantiateSlots();
        inventoryButton.onClick.AddListener(() => ShowPanel(inventoryPanel));
        SellButton.onClick.AddListener(ShowSellConfirmationPanel);
        SellConfirmationButton.onClick.AddListener(InvokeOnItemBuy);
    }

    private void InstantiateSlots()
    {
        ClearSlots();

        foreach (SlotClass slot in items)
        {
            GameObject slotObject = Instantiate(slotPrefab, slotContainer);
            slots.Add(slotObject);

            Image imageComponent = slotObject.transform.GetChild(0).GetComponent<Image>();
            if (imageComponent != null)
            {
                imageComponent.enabled = true;
                imageComponent.sprite = slot.GetItem().Icon;
            }

            Text textComponent = slotObject.transform.GetChild(1).GetComponent<Text>();
            if (textComponent != null)
            {
                textComponent.text = slot.GetQuantity() + " ";
            }

            Button buttonComponent = slotObject.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.RemoveAllListeners(); // Clear existing listeners
                buttonComponent.onClick.AddListener(() => ShowDescriptionPanel(slot.GetItem())); // Add new listener
            }
        }

        currentWeightText.text = "Weight : " + CurrentWeight + " / 50 kg Max";
    }

    private void InvokeOnItemBuy()
    {
        EventService.Instance.OnItemSell.InvokeEvent();
    }

    public void ShowSellConfirmationPanel()
    {
        SellConfirmationPanel.SetActive(true);
        Debug.Log("Sell confirmation panel displayed");
    }
    private void ShowDescriptionPanel(ItemScriptableObject item)
    {
        GameService.Instance.inventoryManager.itemSellPanel.SetActive(false);
        GameService.Instance.inventoryManager.ShopPanel.SetActive(false);
        GameService.Instance.inventoryManager.menuButtons.SetActive(false);


        // Show the description panel with the selected item information
        inventoryDescriptionPanel.SetActive(true);

        ItemView inventoryDescriptionDisplay = inventoryDescriptionPanel.GetComponent<ItemView>();
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
                InstantiateSlots();
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

        InstantiateSlots();
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




    private void ClearSlots()
    {
        foreach (GameObject slot in slots)
        {
            Destroy(slot);
        }
        slots.Clear();
    }

    private void SellItem()
    {
        item = itemDescriptionDisplay.item;
        coinManager.AddCoins(item.SellingPrice);
        RemoveItem(item);
        SellConfirmationPanel.SetActive(false);
    }
}
