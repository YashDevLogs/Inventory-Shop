using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class ResourceGatherer : MonoBehaviour
{
    public float maxWeight;
    public float currentWeight;

    public float veryCommonProbability;
    public float commonProbability;
    public float rareProbability;
    public float epicProbability;
    public float legendaryProbability;

    [SerializeField] private GameObject maxWeightReachedPanel;

    public List<ItemScriptableObject> items = new List<ItemScriptableObject>();

    public Button gatherButton;

    void Start()
    {
        gatherButton.onClick.AddListener(GatherResources);
    }

    void GatherResources()
    {
        if (currentWeight >= maxWeight)
        {
            ShowWeightLimitExceededPopup();
            return;
        }

        ItemRarity rarity = DetermineItemRarity();

        ItemScriptableObject item = SelectRandomItem(rarity);

        GameService.Instance.inventoryManager.AddItem(item);

        currentWeight += item.Weight;
    }

    ItemRarity DetermineItemRarity()
    {
        float randomValue = Random.value;

        if (randomValue < legendaryProbability)
        {
            return ItemRarity.Legendary;
        }
        else if (randomValue < epicProbability)
        {
            return ItemRarity.Epic;
        }
        else if (randomValue < rareProbability)
        {
            return ItemRarity.Rare;
        }
        else if (randomValue < commonProbability)
        {
            return ItemRarity.Common;
        }
        else
        {
            return ItemRarity.VeryCommon;
        }
    }

    ItemScriptableObject SelectRandomItem(ItemRarity rarity)
    {
        List<ItemScriptableObject> filteredItems = items.FindAll(item => item.Rarity == rarity);

        int randomIndex = Random.Range(0, filteredItems.Count);
        return filteredItems[randomIndex];
    }

    void ShowWeightLimitExceededPopup()
    {
        maxWeightReachedPanel.SetActive(true);
    }
}
