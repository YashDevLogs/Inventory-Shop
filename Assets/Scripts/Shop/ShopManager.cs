
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    [SerializeField] public ItemScriptableObject item { get; set; }

    private CoinManager coinManager;
    [SerializeField] private GameObject descriptionPanel;
    [SerializeField] private GameObject inventorypanel;

    private List<ItemScriptableObject> currentItems;

    [SerializeField] private GameObject itemPanel;
    private GameObject BuyConfirmationPanel; 
    private GameObject notEnoughCoinsPanel;

    [SerializeField] private Button materialButton;
    [SerializeField] private Button weaponButton;
    [SerializeField] private Button consumablesButton;
    [SerializeField] private Button treasureButton;
    private Button buyButton;
    private Button buyConfirmationButton;

    [SerializeField] private List<ItemScriptableObject> allItems = new List<ItemScriptableObject>();

    [SerializeField] private GameObject slotPrefab;

    public ItemViewService itemDescriptionDisplay;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {

    }

    private void Start()
    {
        materialButton.onClick.AddListener(() => SetItemType(ItemType.Material));
        weaponButton.onClick.AddListener(() => SetItemType(ItemType.Weapon));
        consumablesButton.onClick.AddListener(() => SetItemType(ItemType.Consumable));
        treasureButton.onClick.AddListener(() => SetItemType(ItemType.Treasure));
    }

    public ShopManager(Button buyButton, GameObject BuyConfirmationPanel, Button buyConfirmationButton, CoinManager coinManager, GameObject notEnoughCoinsPanel)
    {
        this.buyButton = buyButton;
        this.BuyConfirmationPanel = BuyConfirmationPanel;
        this.buyConfirmationButton = buyConfirmationButton;
        this.coinManager = coinManager;
        this.notEnoughCoinsPanel = notEnoughCoinsPanel;
        Debug.Log("Shop service Initialized");

        buyButton.onClick.AddListener(ShowBuyConfirmationPanel);
        buyConfirmationButton.onClick.AddListener(InvokeOnItemBuy);


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
            slot.GetComponent<ItemViewService>().item = item;
            slot.GetComponent<ItemViewService>().shopDescriptionPanel = descriptionPanel;
            slot.GetComponent<ItemViewService>().InventoryPanel = inventorypanel;
        }
    }

    private void InvokeOnItemBuy()
    {
        EventService.Instance.OnItemBuy.InvokeEvent();    
    }

    public void ShowBuyConfirmationPanel()
    {
        GameService.Instance.shopManager.BuyConfirmationPanel.SetActive(true);
    }

/*    public void BuyItem( )
    {
        item = itemDescriptionDisplay.item;
        if (GameService.Instance.shopManager.coinManager.Coins > item.BuyingPrice)
        {  
            GameService.Instance.shopManager.coinManager.DeductCoins(item.BuyingPrice);
            GameService.Instance.inventoryManager.AddItem(item);
            GameService.Instance.shopManager.BuyConfirmationPanel.SetActive(false);
        }
        else
        {
            GameService.Instance.shopManager.notEnoughCoinsPanel.SetActive(true);
        }
    }*/

    public void SetItemType(ItemType type)
    {
        currentItems = allItems.Where(item => item.ItemType == type).ToList();
        PopulatePanel(currentItems);
    }
}

