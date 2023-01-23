namespace Xenoblade_Remake.Quest;

public class QuestExpReward : QuestReward
{
    private int expToGive;

    public QuestExpReward(int expToGive)
    {
        this.expToGive = expToGive;
    }

    public void GiveReward()
    {
        throw new NotImplementedException();
    }
}