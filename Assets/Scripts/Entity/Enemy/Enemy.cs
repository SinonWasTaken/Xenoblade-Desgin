using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : BattleEntity
{
    [SerializeField] private List<EntityAggression> aggressionLevel;

    void Awake()
    {
        //Calculates the enemys stats
        Stats.UpdateEnemyStats(EntityLevel);
        //Sets some of the stats, such as accuracy and evasion, to a default value
        InitData();
        aggressionLevel = new List<EntityAggression>();
    }
    
    //Change method to include a skill or a skill effect parameter. An effect might be bleed, slow, double damage etc...
    public override bool TakeDamage(BattleEntity attacker, int damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, Stats.CalHealthValue);
        
        if (CurrentHealth <= 0)
        {
            //Returns true when the enemy has died
            return true;
        }
        //the code below is only called if the enemy is still alive after being attacked

        //As an enemy is attacked, increase aggression.
        EntityAggression aggressor = hasTargetEntity(attacker);
        if (aggressor == null)
        {
            AggressionLevel.Add(new EntityAggression(attacker, 1));
        }
        else
        {
            increaseEntityAggression(aggressor, 1);
        }
        
        //Only target an entity once the aggression level of the entity is greater than the rest
        aggressionLevel = new List<EntityAggression>(aggressionLevel.OrderBy(x => x.AggressionLevel));
        TargetEntity(aggressionLevel[0].Entity);

        //Returns false if the enemy is still alive
        return false;
    }

    public override void TargetEntity(BattleEntity entity)
    {
        Player player = (Player) entity;
        
        if (hasTargetEntity(player) == null)
        {
            AggressionLevel.Add(new EntityAggression(player, 1));
        }
        
        if (player != null)
        {
            if (player.GetComponent<BattleSystem>() == null)
            {
                player.TargetedByEnemy(this);
            }
        }
    }

    private EntityAggression hasTargetEntity(BattleEntity entity)
    {
        for (int i = 0; i < AggressionLevel.Count; i++)
        {
            if (AggressionLevel[i].Entity == entity)
            {
                return AggressionLevel[i];
            }
        }

        return null;
    }

    private void increaseEntityAggression(EntityAggression aggression, float aggressionValue)
    {
        aggression.AggressionLevel += aggressionValue;
    }
    
    public List<EntityAggression> AggressionLevel => aggressionLevel;
}
