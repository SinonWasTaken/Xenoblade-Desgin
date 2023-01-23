using NekinuSoft;
using NekinuSoft.UI;
using Xenoblade_Remake.Cooking;
using Xenoblade_Remake.PlayerClass;

namespace Xenoblade_Remake.Inventory.Cooking
{
    public class UnlockedCookingRecipes : Component
    {
        private Player player;
        private List<CookingRecipe> unlockedCookingRecipes;
        private CookingRecipe selectedCookingRecipe;
        private Button craftButton;

        public override void Awake()
        {
            if (craftButton != null)
                craftButton.Set_Active(false);

            unlockedCookingRecipes = new List<CookingRecipe>();
        }

        public void EnableCookingUI(bool value)
        {
            //enables the ui for players to cook if value is true
        }

        public void AddCraftingRecipe(CookingRecipe recipe)
        {
            unlockedCookingRecipes.Add(recipe);
        }

        public void OnRecipeUISelected(Button button)
        {
            for (int i = 0; i < unlockedCookingRecipes.Count; i++)
            {
                if (unlockedCookingRecipes[i].RecipeName == button.Parent.EntityName)
                {
                    selectedCookingRecipe = unlockedCookingRecipes[i];
                }
            }
            //called when a recipe is selected in the menu. will give the rest of the ui information on the crafting recipe such as items needed and the effect
            //fill in information
        }

        public void DoCrafting()
        {
            selectedCookingRecipe.DoCrafting( /*player*/);
        }
    }
}