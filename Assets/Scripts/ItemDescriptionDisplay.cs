using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ItemDescriptionDisplay : MonoBehaviour
{
    public ItemScriptableObject item;

    public Image icon;
    public Text nameText;
    public Text descriptionText;
    public Text buyPrice;
    public Text sellPrice;
    public Text quantity;
    public Text weight;
    public Text RarityType;

    public Image rarityButtonImage;
    public Sprite veryCommonSprite;
    public Sprite commonSprite;
    public Sprite rareSprite;
    public Sprite epicSprite;
    public Sprite legendarySprite;
    void Start()
    {
/*        nameText.text = item.Name;
        icon.sprite = item.Icon;
        descriptionText.text = item.ItemDescription;
        buyPrice.text = "Buy Price: $" + item.BuyingPrice.ToString();
        sellPrice.text = "Sell Price: $" + item.SellingPrice.ToString();
        quantity.text = "Quantity: x" + item.Quantity.ToString();
        weight.text = "Weight: " + item.Weight.ToString() + "kg";
        RarityType.text = "Rarity Type : " + item.Rarity;*/

       

    }

    public void DisplayItemDescription(ItemScriptableObject item)
    {
        nameText.text = item.Name;
        icon.sprite = item.Icon;
        descriptionText.text = item.ItemDescription;
        buyPrice.text = "Buy Price: $" + item.BuyingPrice.ToString();
        sellPrice.text = "Sell Price: $" + item.SellingPrice.ToString();
        quantity.text = "Quantity: x" + item.Quantity.ToString();
        weight.text = "Weight: " + item.Weight.ToString() + "kg";
        RarityType.text = "Rarity Type : " + item.Rarity;

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
