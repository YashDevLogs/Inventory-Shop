
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

        // Add onClick events to type buttons
        materialButton.onClick.AddListener(() => SetItemType(ItemType.Material));
        weaponButton.onClick.AddListener(() => SetItemType(ItemType.Weapon));
        consumablesButton.onClick.AddListener(() => SetItemType(ItemType.Consumable));
        treasureButton.onClick.AddListener(() => SetItemType(ItemType.Treasure));

        // Initially populate the panel with all items
/*        PopulatePanel(allItems);*/

    }


    private void PopulatePanel(List<ItemScriptableObject> items)
    {
        // Clear existing items in the panel
        foreach (Transform child in itemPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate new items in the panel
        foreach (ItemScriptableObject item in items)
        {
            GameObject slot = Instantiate(slotPrefab, itemPanel.transform);
            slot.GetComponent<ItemIconDisplay>().item = item;
        }
    }

    private void InvokeOnItemBuy()
    {
        EventService.Instance.OnItemBuy.InvokeEvent();    
    }
/*    private void ShowPanel(GameObject panelToShow)
    {
        MaterialPanel.SetActive(false);
        WeaponPanel.SetActive(false);
        ConsumablesPanel.SetActive(false);
        TreasurePanel.SetActive(false);

        panelToShow.SetActive(true);
    }*/

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
        // Filter items by type
        currentItems = allItems.Where(item => item.ItemType == type).ToList();
        PopulatePanel(currentItems);
    }
}

