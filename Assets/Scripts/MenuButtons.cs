using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons 
{
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private GameObject ShopButton;
    [SerializeField] private GameObject menuButtons;
    [SerializeField] private Button cancleButton;

    public void OpenShop()
    {
        ShopPanel.SetActive(true);
        menuButtons.SetActive(false);
    }

    public void OpenInventoryDescription()
    {
            ShopPanel.SetActive(false);
            menuButtons.SetActive(false);
    }
}
