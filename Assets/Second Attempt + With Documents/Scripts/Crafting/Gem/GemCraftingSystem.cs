using System.Collections.Generic;
using UnityEngine;

public class GemCraftingSystem : MonoBehaviour
{
    private static GemCraftingSystem Instance;
    //private Player player;
    private List<GemRecipe> craftableGems;
    private GemRecipe selectedGemRecipe;
    
    public void Awake()
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

    public void OnGemSelected(/*Button button*/)
    {
        /*for (int i = 0; i < craftableGems.Count; i++)
        {
            if (craftableGems[i].CraftedGemName == button.Parent.EntityName)
            {
                selectedGemRecipe = craftableGems[i];
            }
        }*/
    }
}