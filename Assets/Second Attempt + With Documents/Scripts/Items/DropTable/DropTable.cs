using System;
using System.Collections.Generic;

namespace Xenoblade_Remake.Item
{
    public class DropTable
    {
        private List<DropItem> dropItems;

        private int dropAmount;

        public DropTable(int dropAmount, params DropItem[] items)
        {
            dropItems = new List<DropItem>();
            dropItems.AddRange(items);
            this.dropAmount = dropAmount;
        }

        public ItemData dropItem()
        {
            int maxChance = 0;
            for (int i = 0; i < dropItems.Count; i++)
            {
                maxChance += dropItems[i].DropChance;
            }

            int random = new Random().Next(maxChance);
            int value = 0;

            for (int i = 0; i < dropItems.Count; i++)
            {
                value += dropItems[i].DropChance;

                if (value >= random)
                {
                    return ItemDatabase.Instance.GetItem(dropItems[i].ItemName);
                }
            }

            return null;
        }
    }
}