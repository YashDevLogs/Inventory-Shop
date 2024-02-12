using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemIconDisplay : MonoBehaviour
{
    public ItemScriptableObject item;

    public Image icon;
    public Text nameText;
    public Text buyPrice;
    public Text quantity;
    public Image rarityButtonImage;
    public Sprite veryCommonSprite;
    public Sprite commonSprite;
    public Sprite rareSprite;
    public Sprite epicSprite;
    public Sprite legendarySprite;


    void Start()
    {
        nameText.text = item.Name;
        icon.sprite = item.Icon;
        buyPrice.text = "$" + item.BuyingPrice.ToString(); 
        quantity.text = "x" + item.Quantity.ToString();


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
