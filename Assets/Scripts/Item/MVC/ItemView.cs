using Assets.Scripts.Inventory;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    public ItemController controller { get; private set; }

    [SerializeField] public ItemScriptableObject item;

    [SerializeField] public GameObject shopDescriptionPanel;
    [SerializeField] public GameObject InventoryPanel;

    [SerializeField] private Image icon;
    [SerializeField] private Text iconNameText;
    [SerializeField] private Text iconBuyPrice;
    [SerializeField] private Text iconQuantity;

    [SerializeField] private Image rarityButtonImage;

    [SerializeField] private Sprite veryCommonSprite;
    [SerializeField] private Sprite commonSprite;
    [SerializeField] private Sprite rareSprite;
    [SerializeField] private Sprite epicSprite;
    [SerializeField] private Sprite legendarySprite;

    [SerializeField] private Image descrptionIcon;
    [SerializeField] private Text descriptionNameText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Text descriptionBuyPrice;
    [SerializeField] private Text descriptionSellPrice;
    [SerializeField] private Text descriptionQuantity;
    [SerializeField] private Text descriptionWeight;
    [SerializeField] private Text descriptionRarityType;
    [SerializeField] public SlotClass slot;


    void Start()
    {
        ItemIconDisplay(item);
    }

    public void ItemIconDisplay(ItemScriptableObject item)
    {
        if (iconNameText != null && icon != null && iconBuyPrice != null && iconQuantity != null)
        {
            Debug.Log("All UI elements are not null.");

            iconNameText.text = item.Name;
            icon.sprite = item.Icon;
            iconBuyPrice.text = "$" + item.BuyingPrice.ToString();
            iconQuantity.text = "x" + item.Quantity.ToString();

            SetItemBackgroundImage(item);

            GetComponent<Button>().onClick.AddListener(ShowDescription);
    
        }
        else
        {
            Debug.Log("One or more UI elements is null in ItemView.");
        }
    }


    void ShowDescription()
    {
        if (InventoryPanel != null && shopDescriptionPanel != null)
        {
            // Disable inventory panel
            InventoryPanel.SetActive(false);
            Debug.Log("Inventory panel closed");

            // Enable description panel
            shopDescriptionPanel.SetActive(true);
            Debug.Log("Shop panel Set active");

            // Pass item information to the description panel
            ItemView descriptionDisplay = shopDescriptionPanel.GetComponent<ItemView>();
            descriptionDisplay.DisplayItemDescription(item);
        }
    }


    public void DisplayItemDescription(ItemScriptableObject item)
    {
        if (item != null)
        {
            this.item = item;
            Debug.Log("Item: " + item);
        }
        else if (item == null && slot != null)
        {
            slot.GetItem();
            item = this.item;
        }
        else
        {
            Debug.Log("Item Scriptable Object is Null");
        }
        

        descriptionNameText.text = item.Name;
        descrptionIcon.sprite = item.Icon;
        descriptionText.text = item.ItemDescription;
        descriptionBuyPrice.text = "Buy Price: $" + item.BuyingPrice.ToString();
        descriptionSellPrice.text = "Sell Price: $" + item.SellingPrice.ToString();
        descriptionQuantity.text = "Quantity: x" + item.Quantity.ToString();
        descriptionWeight.text = "Weight: " + item.Weight.ToString() + "kg";
        descriptionRarityType.text = "Rarity Type : " + item.Rarity;

        SetItemBackgroundImage(item);
    }

    public void SetItemBackgroundImage(ItemScriptableObject item)
    {
        switch (item.Rarity)
        {
            case ItemRarity.VeryCommon:
                rarityButtonImage.sprite = veryCommonSprite;
                break;
            case ItemRarity.Common:
                rarityButtonImage.sprite = commonSprite;
                break;
            case ItemRarity.Rare:
                rarityButtonImage.sprite = rareSprite;
                break;
            case ItemRarity.Epic:
                rarityButtonImage.sprite = epicSprite;
                break;
            case ItemRarity.Legendary:
                rarityButtonImage.sprite = legendarySprite;
                break;
            default:
                Debug.LogWarning("Invalid rarity type");
                break;
        }
    }

    public void SetController(ItemController _controller) => controller = _controller;
}