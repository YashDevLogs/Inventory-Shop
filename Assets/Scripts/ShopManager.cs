
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ShopManager : MonoBehaviour
{

    public ItemScriptableObject item;
    [SerializeField] private InventoryManager inventoryManager;   
    


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


    private bool canBuyItem;





    private void Start()
    {

        MaterialButton.onClick.AddListener(() => ShowPanel(MaterialPanel));
        WeaponButton.onClick.AddListener(() => ShowPanel(WeaponPanel));
        ConsumablesButton.onClick.AddListener(() => ShowPanel(ConsumablesPanel));
        TreasureButton.onClick.AddListener(() => ShowPanel(TreasurePanel));
        buyButton.onClick.AddListener(ShowBuyConfirmationPanel);
        buyConfirmationButton.onClick.AddListener(BuyItem);

    

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

    public void BuyItem()
    {
/*        if (canBuyItem == true)
        {
        CoinManager.Instance.DeductCoins(item.BuyingPrice);*/
        inventoryManager.AddItem(item);
        Debug.Log("Item Bought");
        BuyConfirmationPanel.SetActive(false);
        ItemBoughtPanel.SetActive(true);
/*
        }
        else if (canBuyItem == false)
        {
            CoinManager.Instance.ShowNotEnoughCoinPanel();
        }*/
    }

    public void CanBuyItem()
    {
        if(CoinManager.Instance.Coins >= item.BuyingPrice)
        {
            canBuyItem = true;
        }
        else
        {
            canBuyItem = false;
        }

    }

}

