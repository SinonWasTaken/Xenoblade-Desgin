using UnityEngine;

[System.Serializable]
public class EntityAggression
{
    [SerializeField] private BattleEntity entity;
    [SerializeField] private float aggressionLevel;

    public EntityAggression(BattleEntity entity, float aggressionLevel)
    {
        this.entity = entity;
        this.aggressionLevel = aggressionLevel;
    }

    public BattleEntity Entity => entity;

    public float AggressionLevel
    {
        get => aggressionLevel;
        set => aggressionLevel = value;
    }
}
