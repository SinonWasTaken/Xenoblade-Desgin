using System.Collections.Generic;
using UnityEngine;

namespace Xenoblade_Remake.PlayerClass
{
    public class PlayerQuestHandler : MonoBehaviour
    {
        private List<Quest.Quest> unlockedQuests;
        private List<Quest.Quest> completedQuests;

        public void Awake()
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