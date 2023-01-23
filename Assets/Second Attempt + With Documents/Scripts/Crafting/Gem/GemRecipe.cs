namespace Xenoblade_Remake.Crafting.Gem;

public class GemRecipe
{
    private List<RequiredItem> requiredItems;
    private string craftedGemName;

    public GemRecipe(string craftedGemName, params RequiredItem[] requiredItems)
    {
        this.requiredItems = new List<RequiredItem>(); 
        this.requiredItems.AddRange(requiredItems);
        this.craftedGemName = craftedGemName;
    }

    public List<RequiredItem> RequiredItems => requiredItems;

    public string CraftedGemName => craftedGemName;
}