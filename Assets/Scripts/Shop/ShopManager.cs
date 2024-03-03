
using Assets.Scripts.Item;
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
    [SerializeField] private GameObject ItemBoughtPanel; 
    

    [SerializeField] private Button MaterialButton;
    [SerializeField] private Button WeaponButton;
    [SerializeField] private Button ConsumablesButton;
    [SerializeField] private Button TreasureButton;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button buyConfirmationButton;

    public ItemDescriptionDisplay itemDescriptionDisplay;


    private void Start()
    {
        MaterialButton.onClick.AddListener(() => ShowPanel(MaterialPanel));
        WeaponButton.onClick.AddListener(() => ShowPanel(WeaponPanel));
        ConsumablesButton.onClick.AddListener(() => ShowPanel(ConsumablesPanel));
        TreasureButton.onClick.AddListener(() => ShowPanel(TreasurePanel));
        buyButton.onClick.AddListener(ShowBuyConfirmationPanel);
        buyConfirmationButton.onClick.AddListener(BuyItem);
       /* EventService.Instance.OnItemBuy.AddListener(BuyItem);*/

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
        Debug.Log("Item configured");
        inventoryManager.AddItem(item);

        
    }

   
    public bool CanBuyItem() 
    { 
        
        if(item.BuyingPrice < coinManager.Coins) {  canBuyItem = true;}
        else if(item.BuyingPrice > coinManager.Coins) { canBuyItem = false; }

        return canBuyItem;
    }
}

