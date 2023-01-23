public class ArtEffect
{
    public enum ArtEffects
    {
        CriticalUp,
        Poison,
        Burn,
        DoubleDamage,
        EvasionUp,
        EvasionDown,
        AccuracyUp,
        AccuracyDown
    }

    private ArtEffects artEffect;
    private float effectDuration;

    public ArtEffect(ArtEffects artEffect, float effectDuration)
    {
        this.artEffect = artEffect;
        this.effectDuration = effectDuration;
    }

    public ArtEffects CurrentArtEffect => artEffect;

    public float EffectDuration => effectDuration;
}