using UnityEngine;

public class ItemController : MonoBehaviour
{
    private ItemView itemView;
    private CoinManager coinManager;
    private GameObject sellConfirmationPanel;

    public void Initialize(ItemView _itemView, CoinManager _coinManager, GameObject _sellConfirmationPanel)
    {
        itemView = _itemView;
        coinManager = _coinManager;
        sellConfirmationPanel = _sellConfirmationPanel;

        // Add listeners for buy and sell events
        itemView.itemDescriptionDisplay.itemBuyButton.onClick.AddListener(BuyItem);
        itemView.itemDescriptionDisplay.itemSellButton.onClick.AddListener(SellItem);
    }

    private void BuyItem()
    {
        ItemScriptableObject item = itemView.itemDescriptionDisplay.item;

        if (coinManager.Coins >= item.BuyingPrice)
        {
            coinManager.DeductCoins(item.BuyingPrice);
            GameService.Instance.inventoryManager.AddItem(item);
            sellConfirmationPanel.SetActive(false); // Hide the sell confirmation panel
        }
        else
        {
            // Display a message indicating not enough coins
            Debug.LogWarning("Not enough coins to buy this item!");
        }
    }

    private void SellItem()
    {
        ItemScriptableObject item = itemView.itemDescriptionDisplay.item;

        coinManager.AddCoins(item.SellingPrice);
        GameService.Instance.inventoryManager.RemoveItem(item);
        sellConfirmationPanel.SetActive(false); // Hide the sell confirmation panel
    }
}
