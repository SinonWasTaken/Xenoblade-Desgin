using NekinuSoft;
using NekinuSoft.UI;

namespace Xenoblade_Remake.Crafting.Gem;

public class GemCraftingSystem : Component
{
    private static GemCraftingSystem Instance;
    //private Player player;
    private List<GemRecipe> craftableGems;
    private GemRecipe selectedGemRecipe;
    
    public override void Awake()
    {
        loadGemRecpies();
    }

    private void loadGemRecpies()
    {
        craftableGems = new List<GemRecipe>()
        {

        };
    }

    public void EnableCraftingRecipeUI(bool value)
    {
        
    }

    public void OnGemSelected(Button button)
    {
        for (int i = 0; i < craftableGems.Count; i++)
        {
            if (craftableGems[i].CraftedGemName == button.Parent.EntityName)
            {
                selectedGemRecipe = craftableGems[i];
            }
        }
    }
}