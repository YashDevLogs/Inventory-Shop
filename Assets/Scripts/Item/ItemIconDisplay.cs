using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemIconDisplay : MonoBehaviour
{

    [SerializeField] public ItemScriptableObject item;

    [SerializeField] public GameObject shopDescriptionPanel;
    [SerializeField] public GameObject InventoryPanel;

    [SerializeField] private Image icon;
    [SerializeField] private Text nameText;
    [SerializeField] private Text buyPrice;
    [SerializeField] private Text quantity;
    [SerializeField] private Image rarityButtonImage;  
    [SerializeField] private Sprite veryCommonSprite;
    [SerializeField] private Sprite commonSprite;
    [SerializeField] private Sprite rareSprite;
    [SerializeField] private Sprite epicSprite;
    [SerializeField] private Sprite legendarySprite;


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
        GetComponent<Button>().onClick.AddListener(ShowDescription);
    }


    void ShowDescription()
    {
        // Disable inventory panel
        InventoryPanel.SetActive(false);
        Debug.Log("Inventory panel closed");

        // Enable description panel
        shopDescriptionPanel.SetActive(true);
        Debug.Log("Shop panel Set active");

        // Pass item information to the description panel
        ItemInfo descriptionDisplay = shopDescriptionPanel.GetComponent<ItemInfo>();
        descriptionDisplay.DisplayItemDescription(item);
    }

}
