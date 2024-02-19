using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private GameObject ShopButton;
    [SerializeField] private GameObject menuButtons;

    [SerializeField] private Button InventoryCancleButton;
    [SerializeField] private Button ShopCancleButton;
    [SerializeField] private Button BuyConfCancleButton;
    [SerializeField] private Button DescriptionCancleButton;
    [SerializeField] private Button boughtCancleButton;


    [SerializeField] private GameObject InventoryPanel;
    [SerializeField] private GameObject BuyConformationPanel;
    [SerializeField] private GameObject DescriptionPanel;
    [SerializeField] private GameObject MenuButtonsPanel;
    [SerializeField] private GameObject boughtPanel;
 



    private void Start()
    {
        InventoryCancleButton.onClick.AddListener(() => PanelToClose(InventoryPanel));
        ShopCancleButton.onClick.AddListener(() => PanelToClose(ShopPanel));
        BuyConfCancleButton.onClick.AddListener(() => PanelToClose(BuyConformationPanel));
        DescriptionCancleButton.onClick.AddListener(() => PanelToClose(DescriptionPanel));
        boughtCancleButton.onClick.AddListener(() => PanelToClose(boughtPanel));

    }

    public void OpenShop()
    {
        ShopPanel.SetActive(true);
        menuButtons.SetActive(false);
    }

    public void PanelToClose(GameObject Panel)
    {
        if (Panel == ShopPanel )
        { 
            Panel.SetActive(false);
            MenuButtonsPanel.SetActive(true);

        }
        else
            Panel.SetActive(false);
            

    }
}
