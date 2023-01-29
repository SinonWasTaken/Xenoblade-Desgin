using System;

public class Art2 : ArtData2
{
    private float currentArtChargeTime;

    public Art2(string artName, string artDescription, int artBaseDamage, float maxArtCharge, ArtCondition artCondition, ArtEffect artEffect, ArtEffectTarget artTarget, ArtType artType, float currentArtChargeTime) : base(artName, artDescription, artBaseDamage, maxArtCharge, artCondition, artEffect, artTarget, artType)
    {
        this.currentArtChargeTime = currentArtChargeTime;
    }

    public void AddCharge(float charge)
    {
        currentArtChargeTime += charge;
        currentArtChargeTime = Math.Clamp(currentArtChargeTime, 0, MaxArtCharge);
    }
    
    public bool CanUseArt()
    {
        return currentArtChargeTime == MaxArtCharge;
    }

    public bool Update()
    {
        throw new NotImplementedException();
    }
}