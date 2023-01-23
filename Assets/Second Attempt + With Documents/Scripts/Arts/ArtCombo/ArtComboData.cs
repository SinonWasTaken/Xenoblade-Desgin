public class ArtComboData
{
    public enum ArtComboStage
    {
        None,
        Break,
        Topple,
        Launch,
        Smash,
        Burst
    }

    private ArtComboStage comboStage;
    private ArtComboStage stageToOverride;
    private ArtComboStage nextStage;

    private float damageIncreasePercent;
    protected float comboDuration;

    public ArtComboData(ArtComboStage comboStage, ArtComboStage stageToOverride, ArtComboStage nextStage, float damageIncreasePercent, float comboDuration)
    {
        this.comboStage = comboStage;
        this.stageToOverride = stageToOverride;
        this.nextStage = nextStage;
        this.damageIncreasePercent = damageIncreasePercent;
        this.comboDuration = comboDuration;
    }

    public ArtComboStage ComboStage => comboStage;
    public ArtComboStage StageToOverride => stageToOverride;
    public ArtComboStage NextStage => nextStage;

    public float DamageIncreasePercent => damageIncreasePercent;
}