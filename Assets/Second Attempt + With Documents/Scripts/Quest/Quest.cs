using Xenoblade_Remake.Entity;

namespace Xenoblade_Remake.Quest
{
    public class Quest
    {
        private WorldEntity questGiver;
        
        private string questName;
        private QuestType type;
        private bool questComplete;
        private readonly List<QuestObjective> objectives;
        private readonly List<QuestReward> rewards;

        public Quest(string questName, QuestType type, List<QuestObjective> objectives, List<QuestReward> rewards, bool autoCompleteQuest)
        {
            this.questName = questName;
            this.type = type;
            this.objectives = objectives;
            this.rewards = rewards;
            this.autoCompleteQuest = autoCompleteQuest;
        }

        //player doesnt have to return to quest-giver to get reward
        private bool autoCompleteQuest;

        public void TurnInQuest()
        {
            if (isQuestComplete())
            {
                for (int i = 0; i < rewards.Count; i++)
                {
                    rewards[i].GiveReward();
                }

                questComplete = true;
            }
        }

        private bool isQuestComplete()
        {
            for (int i = 0; i < objectives.Count; i++)
            {
                if (!objectives[i].IsObjectiveFinished)
                {
                    return false;
                }
            }

            return true;
        }
        
        public string QuestName => questName;

        public QuestType Type => type;

        public bool QuestComplete => questComplete;
        public bool AutoCompleteQuest => autoCompleteQuest;
    }
}