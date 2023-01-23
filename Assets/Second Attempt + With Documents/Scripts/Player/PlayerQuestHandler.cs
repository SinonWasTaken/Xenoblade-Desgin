using NekinuSoft;

namespace Xenoblade_Remake.PlayerClass
{
    public class PlayerQuestHandler : Component
    {
        private List<Quest.Quest> unlockedQuests;
        private List<Quest.Quest> completedQuests;

        public override void Awake()
        {
            unlockedQuests = new List<Quest.Quest>();
            completedQuests = new List<Quest.Quest>();
        }

        public void AddQuest(Quest.Quest quest)
        {
            unlockedQuests.Add(quest);
        }

        public void CompleteQuest(string questName)
        {
            for (int i = 0; i < unlockedQuests.Count; i++)
            {
                if (unlockedQuests[i].QuestName == questName)
                {
                    completedQuests.Add(unlockedQuests[i]);
                    unlockedQuests.RemoveAt(i);
                }
            }
        }
    }
}