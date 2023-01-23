namespace Xenoblade_Remake.Quest
{
    public class HuntQuest : QuestObjective
    {
        private List<HuntQuestEnemy> enemies;

        public HuntQuest(List<HuntQuestEnemy> enemies)
        {
            this.enemies = enemies;
        }
    }
}

public class HuntQuestEnemy
{
    private string targetName;
    private int amount;
    private int currentAmount;

    public HuntQuestEnemy(string target, int amount)
    {
        targetName = target;
        this.amount = amount;
    }

    public string Target => targetName;

    public int AmountToDefeat => amount;

    public void IncreaseCount()
    {
        currentAmount++;
    }
}