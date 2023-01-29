using System;

public class ArtCombo : ArtComboData
{
    private float currentComboDuration;

    public ArtCombo(ArtComboStage comboStage, ArtComboStage stageToOverride, ArtComboStage nextStage, float damageIncreasePercent, float comboDuration) : base(comboStage, stageToOverride, nextStage, damageIncreasePercent, comboDuration)
    {
        this.currentComboDuration = comboDuration;
    }

    public bool UpdateComboDuration()
    {
        //Reduce the duration over time
        //currentComboDuration -= Time.deltaTime;

        currentComboDuration = Math.Clamp(currentComboDuration, 0, comboDuration);
        
        return currentComboDuration == 0;
    }
}