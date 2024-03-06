using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class ResourceGatherer : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public float maxWeight;
    public float currentWeight;

    // Define the rarity probabilities for each rarity type
    public float veryCommonProbability;
    public float commonProbability;
    public float rareProbability;
    public float epicProbability;
    public float legendaryProbability;

    // Define the item types and their respective weights
    public List<ItemScriptableObject> items = new List<ItemScriptableObject>();

    // Define the button to gather resources
    public Button gatherButton;

    void Start()
    {
        gatherButton.onClick.AddListener(GatherResources);
    }

    void GatherResources()
    {
        // Check if the inventory weight exceeds the maximum weight limit
        if (currentWeight >= maxWeight)
        {
            // Show a popup indicating that the inventory weight limit is exceeded
            ShowWeightLimitExceededPopup();
            return;
        }

        // Determine the rarity of the gathered item based on the cumulative value of the player's inventory
        ItemRarity rarity = DetermineItemRarity();

        // Randomly select an item type based on the determined rarity
        ItemScriptableObject item = SelectRandomItem(rarity);

        // Add the item to the inventory
        inventoryManager.AddItem(item);

        // Update the current weight of the inventory
        currentWeight += item.Weight;
    }

    ItemRarity DetermineItemRarity()
    {
        // Calculate the cumulative value of the player's inventory (for simplicity, let's assume it's based on the number of items)
        int inventoryValue = inventoryManager.GetInventoryCount();

        // Determine the rarity based on the cumulative value
        // You can adjust these thresholds based on your game's balance
        if (inventoryValue < 4)
        {
            return ItemRarity.VeryCommon;
        }
        else if (inventoryValue < 6)
        {
            return ItemRarity.Common;
        }
        else if (inventoryValue < 8)
        {
            return ItemRarity.Rare;
        }
        else if (inventoryValue < 13)
        {
            return ItemRarity.Epic;
        }
        else
        {
            return ItemRarity.Legendary;
        }
    }

    ItemScriptableObject SelectRandomItem(ItemRarity rarity)
    {
        // Filter item types based on rarity
        List<ItemScriptableObject> filteredItems = items.FindAll(item => item.Rarity == rarity);

        // Select a random item from the filtered list
        int randomIndex = Random.Range(0, filteredItems.Count);
        return filteredItems[randomIndex];
    }

    void ShowWeightLimitExceededPopup()
    {
        // Show a popup indicating that the inventory weight limit is exceeded
    }
}
