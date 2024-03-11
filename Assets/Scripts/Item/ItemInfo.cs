using Assets.Scripts.Inventory;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;


public class ItemInfo : MonoBehaviour
{
    [SerializeField] public ItemScriptableObject item;
    [SerializeField] public SlotClass slot;

    [SerializeField] private Image icon;
    [SerializeField] private Text nameText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Text buyPrice;
    [SerializeField] private Text sellPrice;
    [SerializeField] private Text quantity;
    [SerializeField] private Text weight;
    [SerializeField] private Text RarityType;
/*    [SerializeField] private Text BuyPanelName;
    [SerializeField] private Text BuyPanelPrice;*/



    [SerializeField] private Image rarityButtonImage;
    [SerializeField] private Sprite veryCommonSprite;
    [SerializeField] private Sprite commonSprite;
    [SerializeField] private Sprite rareSprite;
    [SerializeField] private Sprite epicSprite;
    [SerializeField] private Sprite legendarySprite;

    public void DisplayItemDescription(ItemScriptableObject item)
    {
        if (item != null)
        {
            this.item = item;
            Debug.Log("Item: " + item);
        }
        else if (item == null &&  slot != null) 
        {
            slot.GetItem();
            item = this.item;
        }
        else
        {
            Debug.Log("Item Scriptable Object is Null");
        }

        nameText.text = item.Name;
        icon.sprite = item.Icon;
        descriptionText.text = item.ItemDescription;
        buyPrice.text = "Buy Price: $" + item.BuyingPrice.ToString();
        sellPrice.text = "Sell Price: $" + item.SellingPrice.ToString();
        quantity.text = "Quantity: x" + item.Quantity.ToString();
        weight.text = "Weight: " + item.Weight.ToString() + "kg";
        RarityType.text = "Rarity Type : " + item.Rarity;

/*        BuyPanelName.text = item.Name;
        BuyPanelPrice.text = item.BuyingPrice.ToString();*/


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
}
