using System.Collections.Generic;
using UnityEngine;
using Xenoblade_Remake.Item;

namespace Xenoblade_Remake.Inventory.Item
{
    public class PlayerInventory : MonoBehaviour
    {
        public const int maxItemSpace = 999;
        
        private List<ItemTab> items;
        
        public static PlayerInventory Instance;
        
        public void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(Instance.gameObject);
            }

            Instance = this;
            items = new List<ItemTab>();
        }

        public int HasItem(ItemData item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Item == item)
                {
                    return items[i].ItemAmount;
                }
            }

            return 0;
        }
        
        public void AddItem(ItemData item, int amount)
        {
            if (HasItem(item) > 0)
            {
                updateItemAmount(item, amount);
            }
            else
            {
                items.Add(new ItemTab(item, amount));
            }
        }
        

        private void updateItemAmount(ItemData item, int amount)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Item == item)
                {
                    items[i].AddItem(amount);
                }
            }
        }

        public void RemoveItem(ItemData item, int amount)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Item == item)
                {
                    updateItemAmount(item, -amount);
                }
            }
        }

        public List<ItemTab> Items => items;
    }

    public class ItemTab
    {
        private ItemData item;
        private int itemAmount;

        public ItemTab(ItemData item, int itemAmount)
        {
            this.item = item;
            this.itemAmount = itemAmount;
        }

        public ItemData Item => item;
        public int ItemAmount => itemAmount;

        public void AddItem(int amount)
        {
            if (amount == PlayerInventory.maxItemSpace)
            {
                AutoSell();
            }
            else
            {
                for (int i = 0; i < amount; i++)
                {
                    if (itemAmount != amount)
                    {
                        itemAmount++;
                    }
                    else
                    {
                        AutoSell();
                    }
                }
                itemAmount += amount;
                
            }
        }
        
        private void AutoSell()
        {
            //Give player money based off sell price of item
        }
    }
}