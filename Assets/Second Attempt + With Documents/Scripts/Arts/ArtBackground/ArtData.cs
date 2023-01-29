public class ArtData2
{
    public enum ArtType
    {
        Physical,
        Ether
    }
    
    private string artName;
    private string artDescription;

    private int artBaseDamage;

    private float maxArtCharge;
    
    private ArtCondition artCondition;

    private ArtEffect artEffect;

    private ArtEffectTarget artTarget;

    private ArtType artType;

    public ArtData2(string artName, string artDescription, int artBaseDamage, float maxArtCharge, ArtCondition artCondition, ArtEffect artEffect, ArtEffectTarget artTarget, ArtType artType)
    {
        this.artName = artName;
        this.artDescription = artDescription;
        this.artBaseDamage = artBaseDamage;
        this.maxArtCharge = maxArtCharge;
        this.artCondition = artCondition;
        this.artEffect = artEffect;
        this.artTarget = artTarget;
        this.artType = artType;
    }

    public string ArtName => artName;
    public string ArtDescription => artDescription;

    public int ArtBaseDamage => artBaseDamage;

    public float MaxArtCharge => maxArtCharge;

    public ArtCondition ArtCondition => artCondition;

    public ArtEffect ArtEffect => artEffect;

    public ArtEffectTarget ArtTarget => artTarget;

    public ArtType Art_Type => artType;
}