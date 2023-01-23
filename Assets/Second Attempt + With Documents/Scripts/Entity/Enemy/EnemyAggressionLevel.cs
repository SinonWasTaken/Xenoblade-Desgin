using Xenoblade_Remake.PlayerClass;

namespace Xenoblade_Remake.Enemy
{
    public class EnemyAggressionLevel
    {
        private PlayerPartyMember target;
        private float aggressionToTarget;

        public EnemyAggressionLevel(PlayerPartyMember target, float aggressionToTarget)
        {
            this.target = target;
            this.aggressionToTarget = aggressionToTarget;
        }

        public void addAggression(float value)
        {
            aggressionToTarget += value;
        }

        public PlayerPartyMember Target => target;

        public float AggressionToTarget => aggressionToTarget;
    }
}