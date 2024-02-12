
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject MaterialPanel;
    [SerializeField] private GameObject WeaponPanel;
    [SerializeField] private GameObject ConsumablesPanel;
    [SerializeField] private GameObject TreasurePanel; 
    
    [SerializeField] private Button MaterialButton;
    [SerializeField] private Button WeaponButton;
    [SerializeField] private Button ConsumablesButton;
    [SerializeField] private Button TreasureButton;


    private void Start()
    {
        MaterialButton.onClick.AddListener(() => ShowPanel(MaterialPanel));
        WeaponButton.onClick.AddListener(() => ShowPanel(WeaponPanel));
        ConsumablesButton.onClick.AddListener(() => ShowPanel(ConsumablesPanel));
        TreasureButton.onClick.AddListener(() => ShowPanel(TreasurePanel));
    }

    private void ShowPanel(GameObject panelToShow)
    {
        MaterialPanel.SetActive(false);
        WeaponPanel.SetActive(false);
        ConsumablesPanel.SetActive(false);
        TreasurePanel.SetActive(false);

        panelToShow.SetActive(true);
    }
}

