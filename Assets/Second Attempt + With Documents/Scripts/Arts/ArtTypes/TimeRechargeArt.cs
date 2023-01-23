public class TimeRechargeArt : Art
{
    private float artGainedPerSecond;

    public TimeRechargeArt(string artName, string artDescription, int artBaseDamage, float maxArtCharge, ArtCondition artCondition, ArtEffect artEffect, ArtEffectTarget artTarget, ArtType artType, float currentArtChargeTime, float artGainedPerSecond) : base(artName, artDescription, artBaseDamage, maxArtCharge, artCondition, artEffect, artTarget, artType, currentArtChargeTime)
    {
        this.artGainedPerSecond = artGainedPerSecond;
    }

    public void AddCharge()
    {
        base.AddCharge(artGainedPerSecond);
    }
}