using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    [System.Serializable]
    public class SlotClass 
    {

        [SerializeField] public ItemScriptableObject item;
        [SerializeField] private int quantity;

        public SlotClass()
        {
            item = null;
            quantity = 0;
        }

            public SlotClass(ItemScriptableObject item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }

        public ItemScriptableObject GetItem() { return item; }
        public int GetQuantity() { return quantity; }
        public void AddQuantity(int _quantity) { quantity += _quantity; }
        public void SubQuantity(int _quantity) { quantity -= _quantity; }
    }
}