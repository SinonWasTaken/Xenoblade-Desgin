using NekinuSoft;

namespace Xenoblade_Remake.Cooking;

public class CookingRecipeDatabase : Component
{
    private static CookingRecipeDatabase Instance;

    private List<CookingRecipe> recipes;
    
    public override void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.Parent);
        }

        Instance = this;
        loadRecipes();
    }

    private void loadRecipes()
    {
        recipes = new List<CookingRecipe>()
        {

        };
    }
}