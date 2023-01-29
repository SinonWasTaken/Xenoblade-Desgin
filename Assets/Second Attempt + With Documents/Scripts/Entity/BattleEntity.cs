using System;
using Xenoblade_Remake.Entity;
using Xenoblade_Remake.Stats;

public class BattleEntity2 : WorldEntity
{
    public const int MaxLevel = 99;
    
    private int currentLevel;
    
    private int currentHealth;
    private BattleStats stats;

    private ArtComboHandler handler;

    public BattleEntity2(string entityName, int currentLevel, int currentHealth, BattleStats stats) : base(entityName)
    {
        this.currentLevel = currentLevel;
        this.currentHealth = currentHealth;
        this.stats = stats;
    }

    public void AddArt(ArtCombo combo)
    {
        handler.AddCombo(combo);
    }

    public virtual void TargetEntity(BattleEntity entity) { }

    public virtual bool TakeDamage(BattleEntity attacker, int damage)
    {
        currentHealth -= damage;

        currentHealth = Math.Clamp(currentHealth, 0, stats.CalculatedHp);

        return currentHealth == 0;
    }
    
    public int CurrentLevel => currentLevel;
    public int CurrentHealth => currentHealth;

    public BattleStats Stats => stats;
}