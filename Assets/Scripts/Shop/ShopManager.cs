
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
 

    public ItemScriptableObject item { get; set; }
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private CoinManager coinManager;

    private bool canBuyItem;


    [SerializeField] private GameObject MaterialPanel;
    [SerializeField] private GameObject WeaponPanel;
    [SerializeField] private GameObject ConsumablesPanel;
    [SerializeField] private GameObject TreasurePanel; 
    [SerializeField] private GameObject BuyConfirmationPanel; 
    [SerializeField] private GameObject itemBoughtPanel;
    [SerializeField] private GameObject notEnoughCoinsPanel;


    [SerializeField] private Button MaterialButton;
    [SerializeField] private Button WeaponButton;
    [SerializeField] private Button ConsumablesButton;
    [SerializeField] private Button TreasureButton;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button buyConfirmationButton;


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
        MaterialButton.onClick.AddListener(() => ShowPanel(MaterialPanel));
        WeaponButton.onClick.AddListener(() => ShowPanel(WeaponPanel));
        ConsumablesButton.onClick.AddListener(() => ShowPanel(ConsumablesPanel));
        TreasureButton.onClick.AddListener(() => ShowPanel(TreasurePanel));
        buyButton.onClick.AddListener(ShowBuyConfirmationPanel);
        buyConfirmationButton.onClick.AddListener(InvokeOnItemBuy);

    }


    private void InvokeOnItemBuy()
    {
        EventService.Instance.OnItemBuy.InvokeEvent();
    }
    private void ShowPanel(GameObject panelToShow)
    {
        MaterialPanel.SetActive(false);
        WeaponPanel.SetActive(false);
        ConsumablesPanel.SetActive(false);
        TreasurePanel.SetActive(false);

        panelToShow.SetActive(true);
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
            itemBoughtPanel.SetActive(true);
        }
        else
        {
            notEnoughCoinsPanel.SetActive(true);
        }

    }
}

