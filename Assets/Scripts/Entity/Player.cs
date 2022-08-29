using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BattleSystem))]
public class Player : BattleEntity
{
    private Input input;

    [Header("Enemy details")]
    [SerializeField] private float enemyCheckRadius;
    
    [SerializeField] private BattleEntity targetedEntity;

    [Header("UI")]
    [SerializeField] private LayerMask ignoreLayer;

    private GameObject DirectionPanel;
    private Transform[] uiDirection;

    private BattleSystem system;

    void Awake()
    {
        Stats.UpdatePlayerStats(EntityLevel);
        InitData();
        system = GetComponent<BattleSystem>();

        DirectionPanel = GameObject.Find("UI").transform.Find("Direction").gameObject;

        uiDirection = new Transform[4];

        for (int i = 0; i < DirectionPanel.transform.childCount; i++)
        {
            uiDirection[i] = DirectionPanel.transform.GetChild(i);
            uiDirection[i].gameObject.SetActive(false);
        }
        
        input = new Input();
        input.PlayerInput.TargetEntity.performed += TargetEntityOnPerformed;
        input.PlayerInput.Test.performed += TestOnPerformed;
        input.Enable();
    }

    private void Start()
    {
        Stats.UpdatePlayerStats(EntityLevel);
    }

    private void TargetEntityOnPerformed(InputAction.CallbackContext obj)
    {
        if (system.TargetedEnemy == null)
        {
            targetedEntity = null;
        }
        
        Collider[] entities = Physics.OverlapSphere(transform.position, enemyCheckRadius, ~ignoreLayer);

        List<Collider> onScreenEnemies = new List<Collider>();
        
        if (entities.Length != 0)
        {
            for (int i = 0; i < entities.Length; i++)
            {
                if (entities[i].GetComponent<Entity>() != null)
                {
                    if (entities[i].GetComponent<Renderer>().isVisible)
                    {
                        Ray ray = new Ray(transform.position, entities[i].transform.position - transform.position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit, enemyCheckRadius))
                        {
                            if (hit.transform.gameObject == entities[i].gameObject)
                            {
                                onScreenEnemies.Add(entities[i]);
                            }
                        }
                    }
                }
            }
        }

        if (onScreenEnemies.Count > 0)
        {
            onScreenEnemies =
                new List<Collider>(onScreenEnemies.OrderBy(x =>
                    Vector3.Distance(transform.position, x.transform.position)));

            TargetEntity(onScreenEnemies[0].GetComponent<BattleEntity>());
        }
        else
        {
            if (targetedEntity != null)
            {
                system.RemoveEnemy(targetedEntity);
                targetedEntity = null;
                system.RemoveTarget();
            }
        }
    }
    
    private void TestOnPerformed(InputAction.CallbackContext obj)
    {
        if (targetedEntity != null)
        {
            system.DoDamage(this, targetedEntity);
        }
        
        if(targetedEntity == null)
            system.RemoveTarget();
    }

    void Update()
    {
        if (targetedEntity != null)
        {
            //Only perform the if/else statement when the player or the targeted entity moves. It will save on performance
            //Is the entity no longer on the screen?
            if (!targetedEntity.GetComponent<Renderer>().isVisible)
            {
                //if a battle hasnt started
                if (!system.BattleStarted)
                {
                    //Set the target to null
                    targetedEntity = null;
                    //Remove the target information from the screen
                    system.RemoveTarget();
                            
                    return;
                }
            }
            else
            {
                //if a battle hasnt started
                if (!system.BattleStarted)
                {
                    //Generates a ray starting at the player, and pointing towards the targeted enemy
                    Ray ray = new Ray(transform.position, targetedEntity.transform.position - transform.position);
                    RaycastHit hit;

                    //Performs a check
                    if (Physics.Raycast(ray, out hit, enemyCheckRadius))
                    {
                        //If the object the ray hits is not the targeted entity
                        if (hit.transform.gameObject != targetedEntity.gameObject)
                        {
                            //Set the target to null
                            targetedEntity = null;
                            //Remove the target information from the screen
                            system.RemoveTarget();
                            
                            return;
                        }
                    }
                }
            }
            
            Transform parent = targetedEntity.transform.Find("Positional Indicators");

            List<Transform> positionIndicator = new List<Transform>();
            
            for (int i = 0; i < parent.childCount; i++)
            {
                positionIndicator.Add(parent.GetChild(i));
            }

            positionIndicator =
                new List<Transform>(positionIndicator.OrderBy(x => Vector3.Distance(x.position, transform.position)));
            
            UpdatePositionIndicator(positionIndicator[0].GetComponent<EntityPosition>().Position);
        }
        else
        {
            if (DirectionPanel.activeSelf)
            {
                DirectionPanel.SetActive(false);
            }
        }
    }

    private void UpdatePositionIndicator(EntityPosition.EntityPositionIndicator pos)
    {
        for (int i = 0; i < uiDirection.Length; i++)
        {
            uiDirection[i].gameObject.SetActive(true);
        }
        
        for (int i = 0; i < uiDirection.Length; i++)
        {
            if (!uiDirection[i].name.Contains(pos.ToString()))
            {
                uiDirection[i].gameObject.SetActive(false);
            }
        }
    }

    public void TargetedByEnemy(BattleEntity entity)
    {
        //Forcibly starts a battle
        system.StartBattle(this, entity);
    }

    public override void TargetEntity(BattleEntity entity)
    {
        if (targetedEntity == null)
        {
            if (entity != targetedEntity)
            {
                setTarget(entity);
            }
            //if the entity is the same, dont update the ui
        }
        else
        {
            setTarget(entity);
        }
    }

    private void setTarget(BattleEntity entity)
    {
        if (!DirectionPanel.activeSelf)
        {
            DirectionPanel.SetActive(true);
        }

        targetedEntity = entity;
        system.SetTarget(entity);
    }
}
