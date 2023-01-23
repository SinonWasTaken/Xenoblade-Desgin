namespace Xenoblade_Remake.Item
{
 public class AccessoryItem : ItemData
 {
     public enum AccessoryEffectConditions
     {
         None,
         Front,
         Left,
         Right,
         Back,
         LowHp,
         HighHp,
         AttackEvaded,
         Outdoors,
         Inside,
         Day,
         Night,
         Targeted
     }
 
     public enum AccessoryEffects
     {
         None,
         AccuracyUp,
         AccuracyDown,
         DamageUp,
         BoostRangeAttackDistance,
         AggroReduction,
         AggroIncrease,
         AgilityUp,
         CriticalUp
     }
 
     private AccessoryEffectConditions condition;
     private AccessoryEffects effect;
     private float effectValue;
 
     public AccessoryItem(string itemName, string itemDescription, ItemRarity rarity, int itemInventoryLimit, int itemShopBuyValue, int itemShopSellValue, AccessoryEffectConditions condition, AccessoryEffects effect, float effectValue) : base(itemName, itemDescription, rarity, itemInventoryLimit, itemShopBuyValue, itemShopSellValue)
     {
         this.condition = condition;
         this.effect = effect;
         this.effectValue = effectValue;
     }
 
     public AccessoryEffectConditions Condition => condition;
     public AccessoryEffects Effect => effect;
 
     public float EffectValue => effectValue;
 }   
}