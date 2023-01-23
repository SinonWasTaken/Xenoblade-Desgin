public class ArtEffectTarget
{
    public enum ArtEffectTargets
    {
        Self,
        RadiusTeam,
        Team,
        SingleOpponent,
        RadiusOpponent,
        ForwardOpponents,
        AllOpponents
    }

    private ArtEffectTargets target;

    public ArtEffectTarget(ArtEffectTargets target)
    {
        this.target = target;
    }

    public ArtEffectTargets Target => target;
}