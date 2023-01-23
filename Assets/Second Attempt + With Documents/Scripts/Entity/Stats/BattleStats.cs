using Xenoblade_Remake.Entity;

namespace Xenoblade_Remake.Stats
{
    public class BattleStats
    {
        private int baseHealthValue;

        private int basePhysicalDefense;
        private int baseEtherDefense;

        private int[] basePhysicalAttack;
        private int[] baseEtherAttack;

        private float healingPower;

        private int dexterity;
        private int agility;

        private float blockRate;
        private float criticalChance;

        private int calculatedHp;

        private int calculatedPhysicalDefense;
        private int calculatedEtherDefense;

        private int calculatedPhysicalAttack;
        private int calculatedEtherAttack;

        private int calculatedDexterity;
        private int calculatedAgility;

        public BattleStats(int baseHealthValue, int basePhysicalDefense, int baseEtherDefense, int[] basePhysicalAttack,
            int[] baseEtherAttack, float healingPower, int dexterity, int agility, float blockRate,
            float criticalChance)
        {
            this.baseHealthValue = baseHealthValue;
            this.basePhysicalDefense = basePhysicalDefense;
            this.baseEtherDefense = baseEtherDefense;
            this.basePhysicalAttack = basePhysicalAttack;
            this.baseEtherAttack = baseEtherAttack;
            this.healingPower = healingPower;
            this.dexterity = dexterity;
            this.agility = agility;
            this.blockRate = blockRate;
            this.criticalChance = criticalChance;
        }

        public static void UpdateStats(BattleEntity entity)
        {

        }

        #region Properties

        public int BaseHealthValue => baseHealthValue;
        public int BasePhysicalDefense => basePhysicalDefense;
        public int BaseEtherDefense => baseEtherDefense;
        public int[] BasePhysicalAttack => basePhysicalAttack;
        public int[] BaseEtherAttack => baseEtherAttack;

        public float HealingPower => healingPower;

        public int Dexterity => dexterity;
        public int Agility => agility;

        public float BlockRate => blockRate;
        public float CriticalChance => criticalChance;

        public int CalculatedHp => calculatedHp;
        public int CalculatedPhysicalDefense => calculatedPhysicalDefense;
        public int CalculatedEtherDefense => calculatedEtherDefense;
        public int CalculatedPhysicalAttack => calculatedPhysicalAttack;
        public int CalculatedEtherAttack => calculatedEtherAttack;
        public int CalculatedDexterity => calculatedDexterity;
        public int CalculatedAgility => calculatedAgility;

        #endregion
    }
}