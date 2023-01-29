using System.Collections.Generic;
using UnityEngine;

public class CookingRecipeDatabase : MonoBehaviour
{
    private static CookingRecipeDatabase Instance;

    private List<CookingRecipe> recipes;
    
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
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