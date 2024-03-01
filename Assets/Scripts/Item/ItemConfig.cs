using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Item
{
    public class ItemConfig : MonoBehaviour
    {
        [SerializeField] private ItemScriptableObject itemScriptableObject;

        private string _itemName { get; set; }
        private string _itemDescription { get; set; }
        private Sprite _itemIcon { get; set; }
        private float _itemBuyPrice { get; set; }
        private float _itemSellPrice { get; set; }
        private ItemRarity _itemRarity { get; set; }
        private float _itemQuantity { get; set; }
        private float _itemWeight { get; set; }

        public ItemConfig(ItemScriptableObject itemScriptableObject)
        {
            _itemName = itemScriptableObject.Name;
            _itemDescription = itemScriptableObject.ItemDescription;
            _itemIcon = itemScriptableObject.Icon;
            _itemBuyPrice = itemScriptableObject.BuyingPrice;
            _itemBuyPrice = itemScriptableObject.SellingPrice;
            _itemRarity = itemScriptableObject.Rarity;
            _itemQuantity = itemScriptableObject.Quantity;
            _itemWeight = itemScriptableObject.Weight;
        }



}
}