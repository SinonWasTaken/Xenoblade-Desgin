namespace Xenoblade_Remake.Crafting;

public class RequiredItem
{
    private string itemName;
    private int requiredAmount;

    public RequiredItem(string itemName, int requiredAmount)
    {
        this.itemName = itemName;
        this.requiredAmount = requiredAmount;
    }

    public string ItemName => itemName;

    public int RequiredAmount => requiredAmount;
}