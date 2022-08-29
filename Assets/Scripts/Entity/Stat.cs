using UnityEngine;

[System.Serializable]
public class Stat
{
    [Header("Base Stat")] 
    [SerializeField] private int baseHealthValue;
    
    [SerializeField] private int basePhysicalDefenseValue;
    [SerializeField] private int baseMagicalDefenseValue;

    [SerializeField] private int basePhysicalAttack;
    [SerializeField] private int baseMagicalAttack;
    
    [SerializeField] private float physicalResistance;
    [SerializeField] private float magicalResistance;

    [Header("Calculated Stats")]
    [SerializeField] private int calHealthValue;
    
    [SerializeField] private int calPhysicalDefense;
    [SerializeField] private int calMagicalDefense;
    [SerializeField] private int[] physicalAttackValues;
    [SerializeField] private int[] magicalAttackValues;

    [Header("Accuracy")]
    [SerializeField] private int accuracyStage = 4;
    private static float[] accuracyValues = {0.5f, 0.67f, 0.85f, 1, 1.15f, 1.37f, 1.5f};
    
    [SerializeField] private int evasionStage = 4;
    private static float[] evasionValues = {1.5f, 1.37f, 1.15f, 1, 0.85f, 0.67f, 0.5f};

    public Stat(int basePhysicalDefenseValue, int baseMagicalDefenseValue, int basePhysicalAttack, int baseMagicalAttack, float physicalResistance, float magicalResistance)
    {
        this.basePhysicalDefenseValue = basePhysicalDefenseValue;
        this.baseMagicalDefenseValue = baseMagicalDefenseValue;
        this.basePhysicalAttack = basePhysicalAttack;
        this.baseMagicalAttack = baseMagicalAttack;
        this.physicalResistance = physicalResistance;
        this.magicalResistance = magicalResistance;
    }

    public void UpdateEnemyStats(int level)
    {
        calHealthValue = SetEnemyHPStat(level);
        
        calMagicalDefense = SetEnemyStats(level, baseMagicalDefenseValue);
        calPhysicalDefense = SetEnemyStats(level, basePhysicalDefenseValue);

        int attack = SetEnemyStats(level, baseMagicalAttack);
        magicalAttackValues = new int[] {attack, (int) (attack * 1.25f)};
        
        attack = SetEnemyStats(level, basePhysicalAttack);
        physicalAttackValues = new int[] {attack, (int) (attack * 1.25f)};
    }

    public void UpdatePlayerStats(int level)
    {
        calHealthValue = SetPlayerHPStat(level);
        
        calMagicalDefense = SetPlayerStats(level, baseMagicalDefenseValue);
        calPhysicalDefense = SetPlayerStats(level, basePhysicalDefenseValue);

        int attack = SetPlayerStats(level, baseMagicalAttack);
        magicalAttackValues = new int[] {attack, (int) (attack * 1.25f)};
        
        attack = SetPlayerStats(level, basePhysicalAttack);
        physicalAttackValues = new int[] {attack, (int) (attack * 1.25f)};
    }

    #region EnemyStats

    private int SetEnemyHPStat(int level)
    {
        float a = (2 * baseHealthValue) * level;
        return (int) (((a / 10) + 20 + level) * 100) * 3;
    }
    private int SetEnemyStats(int level, int stat)
    {
        float a = (2 * stat) * level;
        return (int) (((a / 150f) + 20) * 10);
    }

    #endregion
    
    #region PlayerStats
    
    private int SetPlayerHPStat(int level)
    {
        return (int) ((((2f * baseHealthValue) + 20f + level) * ((100f + level) / 100f)) * 10f);
    }
    private int SetPlayerStats(int level, int stat)
    {
        return (int) ((((2f * stat) * level) / 100f) + 10f) * 10;
    }
    
    #endregion

    public void ModifyAccuracy(int amount)
    {
        accuracyStage += amount;
        accuracyStage = Mathf.Clamp(accuracyStage, 0, accuracyValues.Length - 1);
    }
    public void ResetAccuracy()
    {
        accuracyStage = 4;
    }

    public void ModifyEvasion(int amount)
    {
        evasionStage += amount;
        evasionStage = Mathf.Clamp(evasionStage, 0, accuracyValues.Length - 1);
    }
    public void ResetEvasion()
    {
        evasionStage = 4;
    }

    public int CalHealthValue => calHealthValue;

    public int[] PhysicalAttackValues => physicalAttackValues;
    public int[] MagicalAttackValues => magicalAttackValues;

    public int CalPhysicalDefense => calPhysicalDefense;
    public int CalMagicalDefense => calMagicalDefense;

    public float PhysicalResistance => physicalResistance;
    public float MagicalResistance => magicalResistance;

    public float Accuracy => accuracyValues[accuracyStage];
    public float Evasion => evasionValues[evasionStage];
}
