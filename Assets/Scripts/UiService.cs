using Assets.Scripts.Inventory;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UIService : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private GameObject shopDescriptionPanel;
    [SerializeField] public GameObject inventoryDescriptionPanel { get; private set; }
    [SerializeField] public GameObject maxWeightReachedPanel { get; private set; }
    [SerializeField] private GameObject notEnoughCoinsPanel;
    [SerializeField] public GameObject itemBoughtPanel { get; private set; }
    [SerializeField] private GameObject sellConfirmationPanel;
    [SerializeField] private GameObject BuyConfirmationPanel;
    [SerializeField] private GameObject menuButtons;
    [SerializeField] private Text currentWeightText;

    [Header("Buttons")]
    [SerializeField] private Button inventoryButton;
    [SerializeField] private Button SellButton;
    [SerializeField] private Button SellConfirmationButton;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button buyConfirmationButton;
    [SerializeField] private Button materialButton;
    [SerializeField] private Button weaponButton;
    [SerializeField] private Button consumablesButton;
    [SerializeField] private Button treasureButton;
    [SerializeField] private Button shopButton;

    [SerializeField]
    [Header("Inventory Items")]
    public List<SlotClass> inventoryItems = new List<SlotClass>();
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotContainer;
    private List<GameObject> slots = new List<GameObject>();
    public float CurrentWeight;



    public void Start()
    {
        inventoryButton.onClick.AddListener(() => ShowPanel(inventoryPanel));
        SellButton.onClick.AddListener(ShowSellConfirmationPanel);
        SellConfirmationButton.onClick.AddListener(InvokeOnItemSell);
        buyButton.onClick.AddListener(ShowBuyConfirmationPanel);
        buyConfirmationButton.onClick.AddListener(InvokeOnItemBuy);
    }



    private void ShowPanel(GameObject panelToShow)
    {
        inventoryPanel.SetActive(false);
        shopDescriptionPanel.SetActive(false);

        panelToShow.SetActive(true);
    }
    public void ShowSellConfirmationPanel()
    {
        sellConfirmationPanel.SetActive(true);
    }


    public void InstantiateSlots()
    {
        Debug.Log("Intantiating Slots");

        ClearSlots();

        foreach (SlotClass slot in inventoryItems)
        {
            GameObject slotObject = Instantiate(slotPrefab, slotContainer);
            slots.Add(slotObject);

            Image imageComponent = slotObject.transform.GetChild(0).GetComponent<Image>();
            if (imageComponent != null)
            {
                imageComponent.enabled = true;
                imageComponent.sprite = slot.GetItem().Icon;
            }

            Text textComponent = slotObject.transform.GetChild(1).GetComponent<Text>();
            if (textComponent != null)
            {
                textComponent.text = slot.GetQuantity() + " ";
            }

            Button buttonComponent = slotObject.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.RemoveAllListeners(); // Clear existing listeners
                buttonComponent.onClick.AddListener(() => ShowDescriptionPanel(slot.GetItem())); // Add new listener
            }
        }

        currentWeightText.text = "Weight : " + CurrentWeight + " / 50 kg Max";
        Debug.Log(" Slots instantiated");

    }

    public void ShowDescriptionPanel(ItemScriptableObject item)
    {
        sellConfirmationPanel.SetActive(false);
        ShopPanel.SetActive(false);
        menuButtons.SetActive(false);


        // Show the description panel with the selected item information
        inventoryDescriptionPanel.SetActive(true);

        ItemViewService inventoryDescriptionDisplay = inventoryDescriptionPanel.GetComponent<ItemViewService>();
        inventoryDescriptionDisplay.DisplayItemDescription(item);
    }

    private void ClearSlots()
    {
        foreach (GameObject slot in slots)
        {
            Destroy(slot);
        }
        slots.Clear();
    }
    public void InvokeOnItemSell()
    {
        Debug.Log("item sell Invoking");
        GameService.Instance.eventService.OnItemSell.InvokeEvent();
        Debug.Log("item sell Invoked");
    }

    private void InvokeOnItemBuy()
    {
        EventService.Instance.OnItemBuy.InvokeEvent();
    }

    public void ShowBuyConfirmationPanel()
    {
        BuyConfirmationPanel.SetActive(true);

    }
}

