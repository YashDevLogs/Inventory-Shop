using Assets.Scripts.Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotContainer;
    [SerializeField] public ItemScriptableObject item { get; set; }

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

    private void Start()
    {
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
    }
    private void ShowDescriptionPanel(ItemScriptableObject item)
    {
        itemSellPanel.SetActive(false);
        ShopPanel.SetActive(false);
        menuButtons.SetActive(false);


        // Show the description panel with the selected item information
        inventoryDescriptionPanel.SetActive(true);

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
                InstantiateSlots();
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
