using System.Collections.Generic;

public class ArtComboDatabase
{
    private static ArtComboDatabase Instance;

    private List<ArtCombo> combos;

    public static ArtComboDatabase getInstance()
    {
        if (Instance == null)
        {
            Instance = new ArtComboDatabase();
        }

        return Instance;
    }
    
    public ArtComboDatabase()
    {
        loadArtCombo();
    }

    private void loadArtCombo()
    {
        combos = new List<ArtCombo>()
        {
            new ArtCombo(ArtComboData.ArtComboStage.Break, ArtComboData.ArtComboStage.None, ArtComboData.ArtComboStage.Topple, 1.05f, 12f),
            new ArtCombo(ArtComboData.ArtComboStage.Topple, ArtComboData.ArtComboStage.Break, ArtComboData.ArtComboStage.Launch, 1.13f, 15),
            new ArtCombo(ArtComboData.ArtComboStage.Launch, ArtComboData.ArtComboStage.Topple, ArtComboData.ArtComboStage.None,1.35f, 15),
            new ArtCombo(ArtComboData.ArtComboStage.Smash, ArtComboData.ArtComboStage.Launch,  ArtComboData.ArtComboStage.None, 3f, 0),
            new ArtCombo(ArtComboData.ArtComboStage.Burst, ArtComboData.ArtComboStage.Topple, ArtComboData.ArtComboStage.None, 1, 1)
        };
    }

    public ArtCombo GetCombo(ArtComboData.ArtComboStage stage)
    {
        for (int i = 0; i < combos.Count; i++)
        {
            if (combos[i].ComboStage == stage)
            {
                return combos[i];
            }
        }

        return null;
    }
}