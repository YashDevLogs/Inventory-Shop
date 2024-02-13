using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<ItemScriptableObject> items = new List<ItemScriptableObject>();

    [SerializeField] private GameObject SlotHolder;

    public ItemScriptableObject ItemsToAdd;
    public ItemScriptableObject ItemsToRemove;

    public GameObject InventoryPanel;
    public GameObject DescriptionPanel;
    public Button InventoryButton;

    private GameObject[] Slots;
    private void Start()
    {
        InventoryButton.onClick.AddListener(() => ShowPanel(InventoryPanel));
    }

    public void Add(ItemScriptableObject item) => items.Add(item);
    public void Remove(ItemScriptableObject item) => items.Remove(item);


    private void ShowPanel(GameObject panelToShow)
    {
        InventoryPanel.SetActive(false);
        DescriptionPanel.SetActive(false);

        panelToShow.SetActive(true);
    }
}
