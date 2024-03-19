using ServiceLocator.Utilities;
using UnityEngine;
using UnityEngine.UI;

public class GameService : GenericMonoSingleton<GameService>
{
    [Header("Inventoy manager references")]
    public InventoryManager inventoryManager;

    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotContainer;
    [SerializeField] private Text currentWeightText;
    [SerializeField] private GameObject shopDescriptionPanel;
    [SerializeField] private GameObject maxWeightReachedPanel;
    [SerializeField] private GameObject itemBoughtPanel;
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private GameObject inventoryDescriptionPanel;
    [SerializeField] private GameObject menuButtons;
    [SerializeField] private GameObject itemSellPanel;
    [SerializeField] private Button SellButton;
    [SerializeField] private Button SellConfirmationButton;


    [Header("Shop manager references")]
    public ShopManager shopManager;

    [SerializeField] private Button buyButton;
    [SerializeField] private GameObject BuyConfirmationPanel; 
    [SerializeField] private Button buyConfirmationButton;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private GameObject notEnoughCoinsPanel;

    public EventService eventService;


    private void Start()
    {
        InitializeServices();
    }

    private void InitializeServices()
    {
        inventoryManager = new InventoryManager(
            SellButton,
            SellConfirmationButton,
            inventoryPanel,
            shopDescriptionPanel,
            inventoryButton,
            currentWeightText,
            slotPrefab,
            slotContainer,
            itemBoughtPanel,
            maxWeightReachedPanel,
            ShopPanel,
            inventoryDescriptionPanel,
            menuButtons,
            itemSellPanel
        );

        shopManager = new ShopManager(buyButton, BuyConfirmationPanel, buyConfirmationButton, coinManager, notEnoughCoinsPanel);

        eventService = new EventService();

    }

}
