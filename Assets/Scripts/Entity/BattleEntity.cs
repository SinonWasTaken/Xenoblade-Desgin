using UnityEngine;

[RequireComponent(typeof(ArtController))]
public class BattleEntity : Entity
{
    [Header("Battle Entity Stats")]
    [SerializeField] private int entityLevel;
    [SerializeField] private int currentHealth;
    
    [SerializeField] private Stat stats;

    private ArtController artController;

    protected void InitData()
    {
        artController = GetComponent<ArtController>();
        
        stats.ResetAccuracy();
        stats.ResetEvasion();

        currentHealth = stats.CalHealthValue;
    }
    
    public void AddArt(Art art)
    {
        artController.AddArt(art);
    }
    
    public virtual void TargetEntity(BattleEntity entity) { }
    
    public virtual bool TakeDamage(BattleEntity attacker, int damage)
    {
        return false;
    }

    public Stat Stats => stats;

    public int CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }
    public int EntityLevel => entityLevel;
}
