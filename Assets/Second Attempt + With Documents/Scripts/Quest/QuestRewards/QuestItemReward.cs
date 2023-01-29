using System.Collections.Generic;
using Xenoblade_Remake.Inventory.Item;
using Xenoblade_Remake.Item;

public class QuestItemReward : QuestReward
{
    private List<ItemReward> rewards;

    public QuestItemReward(params ItemReward[] rewards)
    {
        this.rewards = new List<ItemReward>();
        this.rewards.AddRange(rewards);
    }

    public void GiveReward()
    {
        for (int i = 0; i < rewards.Count; i++)
        {
            PlayerInventory.Instance.AddItem(rewards[i].Item, rewards[i].Amount);
        }
    }
}

public class ItemReward
{
    private ItemData item;
    private int amount;

    public ItemReward(ItemData item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public ItemData Item => item;
    public int Amount => amount;
}