using Xenoblade_Remake.Item;
using Xenoblade_Remake.PlayerClass;
using Xenoblade_Remake.Stats;

namespace Xenoblade_Remake.Enemy
{

    public class Enemy : BattleEntity
    {
        private EnemyAttackType attackType;
        private EnemyMoveType moveType;
        
        private List<EnemyAggressionLevel> targets;
        private DropTable table;

        private int expToGiveOut;

        public Enemy(string entityName, int currentLevel, int currentHealth, BattleStats stats,
            List<EnemyAggressionLevel> targets, DropTable table, int expTogiveOut) :
            base(entityName, currentLevel, currentHealth, stats)
        {
            this.targets = targets;
            this.table = table;
            expToGiveOut = expTogiveOut;
        }

        public void AddAggressionToTarget(PlayerPartyMember member, float value)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i].Target == member)
                {
                    targets[i].addAggression(value);
                }
            }
        }

        public void RemoveAggressionTarget(PlayerPartyMember member)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i].Target == member)
                {
                    targets.RemoveAt(i);
                }
            }
        }

        public bool hasAlreadyTargetedMember(PlayerPartyMember member)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i].Target == member)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetExpYield()
        {
            //calculate yield by level difference
            return expToGiveOut;
        }
    }
}