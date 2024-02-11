using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemDisplay : MonoBehaviour
{
    public ItemScriptableObject item;

    public Image icon;
    public Text nameText;
    public Text descriptionText;
    public Text buyPrice;
    public Text sellPrice;
    public Text quantity;
    public Text weight;
    void Start()
    {
        nameText.text = item.name;
        icon.sprite = item.Icon;
        buyPrice.text = item.BuyingPrice.ToString( buyPrice.text);
        sellPrice.text = item.SellingPrice.ToString( sellPrice.text);
        quantity.text = item.Quantity.ToString(quantity.text);
        weight.text = item.Weight.ToString(weight.text );
    }

}
