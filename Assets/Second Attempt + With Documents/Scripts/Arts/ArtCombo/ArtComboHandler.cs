public class ArtComboHandler
{
    private ArtCombo combo;

    public void Update()
    {
        if (combo != null)
        {
            if (combo.UpdateComboDuration())
            {
                combo = null;
            }
        }
    }
    
    public void AddCombo(ArtCombo newCombo)
    {
        if (combo.ComboStage == newCombo.ComboStage)
        {
            combo = ArtComboDatabase.getInstance().GetCombo(newCombo.NextStage);
        }
        else if (combo.ComboStage == newCombo.StageToOverride)
        {
            if (newCombo.NextStage != ArtComboData.ArtComboStage.None)
            {
                combo = ArtComboDatabase.getInstance().GetCombo(newCombo.ComboStage);
            }
            else
            {
                combo = ArtComboDatabase.getInstance().GetCombo(newCombo.NextStage);
            }
        }
    }
}