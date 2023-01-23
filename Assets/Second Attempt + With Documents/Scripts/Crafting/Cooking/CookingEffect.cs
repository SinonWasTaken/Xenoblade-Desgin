namespace Xenoblade_Remake.Cooking;

public class CookingEffect
{
    public enum FoodEffect
    {
        ExpBoost,
        CPBoost,
        GoldBoost,
        DropBoost
    }

    private FoodEffect effect;
    private float effectDuration, increasePercent;

    public FoodEffect Effect => effect;

    public float EffectDuration => effectDuration;
    public float IncreasePercent => increasePercent;
}