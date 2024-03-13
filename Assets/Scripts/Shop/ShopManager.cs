
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    [SerializeField] public ItemScriptableObject item { get; set; }

    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private GameObject descriptionPanel;
    [SerializeField] private InputField quantity;
    [SerializeField] private GameObject inventorypanel;

    private List<ItemScriptableObject> currentItems;

    [SerializeField] private GameObject itemPanel;
    [SerializeField] private GameObject BuyConfirmationPanel; 
    [SerializeField] private GameObject itemBoughtPanel;
    [SerializeField] private GameObject notEnoughCoinsPanel;

    [SerializeField] private Button materialButton;
    [SerializeField] private Button weaponButton;
    [SerializeField] private Button consumablesButton;
    [SerializeField] private Button treasureButton;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button buyConfirmationButton;

    [SerializeField] private List<ItemScriptableObject> allItems = new List<ItemScriptableObject>();

    [SerializeField] private GameObject slotPrefab;

    public ItemInfo itemDescriptionDisplay;

    private void OnEnable()
    {
        EventService.Instance.OnItemBuy.AddListener(BuyItem);
    }

    private void OnDisable()
    {
        EventService.Instance.OnItemBuy.RemoveListener(BuyItem);
    }

    private void Start()
    {
        buyButton.onClick.AddListener(ShowBuyConfirmationPanel);
        buyConfirmationButton.onClick.AddListener(InvokeOnItemBuy);

        materialButton.onClick.AddListener(() => SetItemType(ItemType.Material));
        weaponButton.onClick.AddListener(() => SetItemType(ItemType.Weapon));
        consumablesButton.onClick.AddListener(() => SetItemType(ItemType.Consumable));
        treasureButton.onClick.AddListener(() => SetItemType(ItemType.Treasure));
    }

    private void PopulatePanel(List<ItemScriptableObject> items)
    {
        foreach (Transform child in itemPanel.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (ItemScriptableObject item in items)
        {
            GameObject slot = Instantiate(slotPrefab, itemPanel.transform);
            slot.GetComponent<ItemIconDisplay>().item = item;
            slot.GetComponent<ItemIconDisplay>().shopDescriptionPanel = descriptionPanel;
            slot.GetComponent<ItemIconDisplay>().InventoryPanel = inventorypanel;
        }
    }

    private void InvokeOnItemBuy()
    {
        EventService.Instance.OnItemBuy.InvokeEvent();    
    }

    public void ShowBuyConfirmationPanel()
    {
        BuyConfirmationPanel.SetActive(true);
    }

    public void BuyItem( )
    {
        item = itemDescriptionDisplay.item;
        if (coinManager.Coins > item.BuyingPrice)
        {  
            coinManager.DeductCoins(item.BuyingPrice);
            inventoryManager.AddItem(item);
            BuyConfirmationPanel.SetActive(false);
        }
        else
        {
            notEnoughCoinsPanel.SetActive(true);
        }
    }

    public void SetItemType(ItemType type)
    {
        currentItems = allItems.Where(item => item.ItemType == type).ToList();
        PopulatePanel(currentItems);
    }
}

