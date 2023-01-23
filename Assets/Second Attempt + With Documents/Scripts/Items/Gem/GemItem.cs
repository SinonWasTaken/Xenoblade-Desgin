using Xenoblade_Remake.Item.Effect;

namespace Xenoblade_Remake.Item
{
    public class GemItem : ItemData
    {
        private GemEffect effect;
        private float effectValue;

        public GemItem(string itemName, string itemDescription, ItemRarity rarity, int itemInventoryLimit,
            int itemShopBuyValue, int itemShopSellValue, GemEffect effect, float effectValue) : base(itemName,
            itemDescription, rarity, itemInventoryLimit, itemShopBuyValue, itemShopSellValue)
        {
            this.effect = effect;
            this.effectValue = effectValue;
        }

        public GemEffect Effect => effect;

        public float EffectValue => effectValue;
    }   
}