using Xenoblade_Remake.Crafting;

namespace Xenoblade_Remake.Cooking;

public class CookingRecipe : Crafting.Crafting
{
    private string recipeName;
    private List<RequiredItem> requiredItems;
    private List<CookingEffect> effects;

    public CookingRecipe(string recipeName, List<RequiredItem> requiredItems, List<CookingEffect> effects)
    {
        this.recipeName = recipeName;
        this.requiredItems = requiredItems;
        this.effects = effects;
    }

    public string RecipeName => recipeName;

    public List<RequiredItem> RequiredItems => requiredItems;

    public List<CookingEffect> Effects => effects;

    public void DoCrafting()
    {
        throw new NotImplementedException();
    }
}