using ServiceLocator.Utilities;
using UnityEngine;
using UnityEngine.UI;

public class GameService : GenericMonoSingleton<GameService>
{
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

    private bool sellButtonActivated = false;
    private bool sellConfirmationButtonActivated = false;


    private void Start()
    {
        inventoryManager = new InventoryManager(
            null, // Pass null for SellButton
            null, // Pass null for SellConfirmationButton
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
    }

    private void Update()
    {

        if (SellButton.gameObject.activeInHierarchy && !sellButtonActivated)
        {
            inventoryManager.SetupSellButton(SellButton);
            sellButtonActivated = true;
        }

        if (SellConfirmationButton.gameObject.activeInHierarchy && !sellConfirmationButtonActivated)
        {
            inventoryManager.SetupSellConfirmationButton(SellConfirmationButton);
            sellConfirmationButtonActivated = true;
        }
    }
}
