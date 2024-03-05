using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemDisplay : MonoBehaviour
{
    public ItemScriptableObject item;
    [SerializeField] private GameObject itemSellPanel;
    public GameObject InventorydescriptionPanel;

    public Image icon;
    public Text sellPrice;
    public Text quantity;




    private void Start()
    {


        GetComponent<Button>().onClick.AddListener(InventroyDescription);
    }

    private void InventroyDescription()
    {
        InventorydescriptionPanel.SetActive(true);

        itemSellPanel.SetActive(true);
        Debug.Log("Button Clicked");

        ItemInfo descriptionDisplay = InventorydescriptionPanel.GetComponent<ItemInfo>();
        descriptionDisplay.DisplayItemDescription(item);
    }
}
