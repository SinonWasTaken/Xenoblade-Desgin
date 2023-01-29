public class DamageRechargeArt : Art2
{
    private float chargeGrantedOnHit;

    public DamageRechargeArt(string artName, string artDescription, int artBaseDamage, float maxArtCharge, ArtCondition artCondition, ArtEffect artEffect, ArtEffectTarget artTarget, ArtType artType, float currentArtChargeTime, float chargeGrantedOnHit) : base(artName, artDescription, artBaseDamage, maxArtCharge, artCondition, artEffect, artTarget, artType, currentArtChargeTime)
    {
        this.chargeGrantedOnHit = chargeGrantedOnHit;
    }

    public void AddCharge()
    {
        base.AddCharge(chargeGrantedOnHit);
    }
}