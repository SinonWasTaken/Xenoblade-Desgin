using System.Collections.Generic;
using Xenoblade_Remake.Inventory.Item;
using Xenoblade_Remake.Item;

public class CollectionQuest : QuestObjective
{
    private List<CollectionQuestItem> itemsNeeded;

    public void CheckForItemInInventory(ItemData item)
    {
        int completedItems = 0;
        for (int i = 0; i < itemsNeeded.Count; i++)
        {
            if (itemsNeeded[i].ItemNeeded == item)
            {
                if (!itemsNeeded[i].HasAmountNeeded)
                {
                    int amountPlayerHas = PlayerInventory.Instance.HasItem(item);

                    if (amountPlayerHas >= itemsNeeded[i].AmountNeeded)
                    {
                        itemsNeeded[i].DoneWithItem();
                        completedItems++;
                    }
                }
                else
                {
                    completedItems++;
                }
            }
        }

        if (completedItems == itemsNeeded.Count)
        {
            CompleteObjective();
        }
    }

    public void StartObjective()
    {
        for (int i = 0; i < itemsNeeded.Count; i++)
        {
            CheckForItemInInventory(itemsNeeded[i].ItemNeeded);
        }
    }
}

public class CollectionQuestItem
{
    private ItemData itemNeeded;
    private int amountNeeded;

    private bool hasAmountNeeded;

    public CollectionQuestItem(ItemData itemNeeded, int amountNeeded)
    {
        this.itemNeeded = itemNeeded;
        this.amountNeeded = amountNeeded;
    }

    public ItemData ItemNeeded => itemNeeded;
    public int AmountNeeded => amountNeeded;

    public bool HasAmountNeeded => hasAmountNeeded;

    public void DoneWithItem()
    {
        hasAmountNeeded = true;
    }
}