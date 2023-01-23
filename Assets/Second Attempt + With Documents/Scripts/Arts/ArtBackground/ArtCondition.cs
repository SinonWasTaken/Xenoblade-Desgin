public class ArtCondition
{
    public enum ArtConditions
    {
        Cancel,
        Forward,
        Left,
        Right,
        Back,
        Break,
        Topple,
        Launch,
        Smash,
        Burst
    }

    private ArtConditions artCondition;

    public ArtCondition(ArtConditions artCondition)
    {
        this.artCondition = artCondition;
    }

    public ArtConditions ArtCondition1 => artCondition;
}