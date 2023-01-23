namespace Xenoblade_Remake.Item
{
    public class ItemData
    {
        public enum ItemRarity
        {
            Common,
            Rare,
            Legendary
        }

        public enum ItemType
        {
            Key,
            Collectible,
            Accessory,
            Gem
        }
        private string itemName;
        private string itemDescription;

        private ItemRarity rarity;
        private ItemType type;

        private int itemInventoryLimit;
    
        private int itemShopBuyValue;
        private int itemShopSellValue;

        public ItemData(string itemName, string itemDescription, ItemRarity rarity, int itemInventoryLimit, int itemShopBuyValue, int itemShopSellValue)
        {
            this.itemName = itemName;
            this.itemDescription = itemDescription;
            this.rarity = rarity;
            this.itemInventoryLimit = itemInventoryLimit;
            this.itemShopBuyValue = itemShopBuyValue;
            this.itemShopSellValue = itemShopSellValue;
        }

        public string ItemName => itemName;

        public string ItemDescription => itemDescription;

        public ItemRarity Rarity => rarity;

        public int ItemInventoryLimit => itemInventoryLimit;

        public int ItemShopBuyValue => itemShopBuyValue;

        public int ItemShopSellValue => itemShopSellValue;

        public ItemType Type => type;
    }   
}