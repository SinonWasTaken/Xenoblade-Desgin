using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private List<BattleEntity> enemies;

    [SerializeField] private BattleEntity targetedEnemy;
    
    [SerializeField] private GameObject enemyInfoPanel;
    [SerializeField] private TextMeshProUGUI enemyName;
    [SerializeField] private TextMeshProUGUI enemyLevel;
    [SerializeField] private Slider healthSlider;

    [SerializeField] private bool battleStarted;
    
    private void Awake()
    {
        enemyInfoPanel = GameObject.Find("UI").transform.Find("EnemyInfo").gameObject;
        Transform panel = enemyInfoPanel.transform.Find("Panel"); 
        
        enemyName = panel.Find("Enemy Name").Find("Name").GetComponent<TextMeshProUGUI>();
        enemyLevel = panel.Find("EnemyLv").Find("Lv").GetComponent<TextMeshProUGUI>();
        healthSlider = panel.Find("EnemyHPBar").Find("Slider").GetComponent<Slider>();
        
        enemyInfoPanel.SetActive(false);
    }

    public void StartBattle(Player player, BattleEntity entity)
    {
        enemies = new List<BattleEntity>();
        enemies.Add(entity);

        targetedEnemy = entity;
        
        enemyInfoPanel.SetActive(true);

        battleStarted = true;
        Debug.Log(calculateExpEarned(player, entity));
    }

    public void AddEnemy(BattleEntity enemy)
    {
        //When a new enemy comes into the battle, check if the enemy is a unique enemy, and change the music accordingly
        enemies.Add(enemy);
    }

    public void RemoveEnemy(BattleEntity enemy)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemy == enemies[i])
            {
                enemies.Remove(enemies[i]);
            }
        }
    }

    public void SetTarget(BattleEntity entity)
    {
        targetedEnemy = entity;
        
        DisplayTargetEnemyInfo(targetedEnemy);
    }
    
    public void RemoveTarget()
    {
        //When a target dies, check to see if there are any other enemies in the fight, and target the enemy with the lowest health (percentage wise: CurrentHealth/CalculatedHealth) 
        enemyInfoPanel.SetActive(false);
        targetedEnemy = null;
    }

    public void EndBattle()
    {
        targetedEnemy = null;
        enemies = new List<BattleEntity>();
        enemyInfoPanel.SetActive(false);

        battleStarted = false;
    }
    
    public void DoDamage(BattleEntity attacker, BattleEntity defender/*, Skill skill*/)
    {
        if (attacker != null)
        {
            if (doesMoveHit(attacker, defender))
            {
                float damage = 0;
                float skillDamage = 10;

                float resistance = 1;

                bool isPhysical = false;

                isPhysical = true;

                damage = Random.Range(attacker.Stats.PhysicalAttackValues[0], attacker.Stats.PhysicalAttackValues[1]);
                resistance *= defender.Stats.PhysicalResistance;

                float weaponAttachments = 1;

                float weak = 1;

                float defenderDefense =
                    isPhysical ? defender.Stats.CalPhysicalDefense : defender.Stats.CalMagicalDefense;

                int finalDamage = (int) ((damage * weaponAttachments) * (skillDamage / 10f) * weak *
                                         (defenderDefense / resistance) / 100);
                
                bool dead = defender.TakeDamage(attacker, finalDamage);

                if (!dead)
                {
                    if (defender == targetedEnemy)
                    {
                        UpdateEnemyHealthSlider(defender);
                    }
                }
                else
                {
                    //Once a enemy is dead, calculate exp
                        //If the player is a higher level than the enemy, then for each level higher, the player loses 10% of the expierence.
                        //Example: (2 Levels higher) (Base exp drop: 500exp) for int i = 0; i < 2: i++ : 500 * 0.9 = 450 which mean 50 exp is lost per level, so at the end the player earns 400 exp
                    
                    RemoveEnemy(defender);
                    Destroy(defender.gameObject);
                    RemoveTarget();
                }
            }

            if (defender is Enemy)
            {
                if (!battleStarted)
                {
                    StartBattle((Player) attacker, defender);
                }
                else
                {
                    if (!isEnemyInBattle((Enemy) defender))
                    {
                        AddEnemy(defender);
                    }
                }
            }

            if (enemies.Count == 0)
            {
                EndBattle();
            }
        }
    }

    private bool isEnemyInBattle(Enemy enemy) 
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == enemy)
                return true;
        }

        return false;
    }

    private int calculateExpEarned(BattleEntity attacker, BattleEntity defender)
    {
        //set exp to the defeated enemy's expYieldAmount
        int exp = 145;

        float a = (exp * defender.EntityLevel) / 10f;
        float b = Mathf.Pow(((2f * defender.EntityLevel) + 20f) / (defender.EntityLevel + attacker.EntityLevel + 20f),
            3f);

        float c = (defender.EntityLevel * 1f) / (attacker.EntityLevel * 1f);
        
        return (int) ((((a * b) + 1f) * 2f) * c);
    }
    
    private bool doesMoveHit(BattleEntity attacker, BattleEntity defender)
    {
        float accuracy = attacker.Stats.Accuracy * defender.Stats.Evasion;

        return Random.Range(0, 1) <= accuracy;
    }

    private void DisplayTargetEnemyInfo(BattleEntity target)
    {
        enemyInfoPanel.SetActive(true);
        
        enemyName.text = target.EntityName;
        enemyLevel.text = $"lv.{target.EntityLevel}";
        healthSlider.maxValue = target.Stats.CalHealthValue;
        
        UpdateEnemyHealthSlider(target);
    }

    private void UpdateEnemyHealthSlider(BattleEntity target)
    {
        healthSlider.value = target.CurrentHealth;
    }

    public bool BattleStarted => battleStarted;

    public BattleEntity TargetedEnemy => targetedEnemy;
}
