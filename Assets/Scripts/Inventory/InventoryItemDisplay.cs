using UnityEngine;
using UnityEngine.UI;

public class InventoryItemDisplay : MonoBehaviour
{
    public ItemScriptableObject item;

    [SerializeField] private GameObject itemSellPanel;
    public GameObject inventoryDescriptionPanel;
    [SerializeField] private GameObject menuButtons;
    [SerializeField] private GameObject ShopPanel;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowDescription);
    }

    private void ShowDescription()
    {

        // Disable item sell panel
        itemSellPanel.SetActive(false);
        ShopPanel.SetActive(false);
        menuButtons.SetActive(false);
        

        // Enable inventory description panel
        inventoryDescriptionPanel.SetActive(true);

        // Pass item information to the description panel
        ItemInfo inventoryDescriptionDisplay = inventoryDescriptionPanel.GetComponent<ItemInfo>();
        inventoryDescriptionDisplay.DisplayItemDescription(item);
    }
}
