using System.Collections.Generic;
using UnityEngine;
using Xenoblade_Remake.Item;
using Xenoblade_Remake.Item.Effect;

public class ItemDatabase : MonoBehaviour
{
    //A static instance of ItemDatabase.
    public static ItemDatabase Instance;

    //List of all items in the game
    private List<ItemData> items;
    
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
    }

    public ItemDatabase()
    {
        //Loads all items
        loadItems();
    }

    //Method to load all items into data
    private void loadItems()
    {
        items = new List<ItemData>()
        {
            new AccessoryItem("testItem", "testDescription", ItemData.ItemRarity.Legendary, 99, 250, 0, AccessoryItem.AccessoryEffectConditions.None, AccessoryItem.AccessoryEffects.None, 0),
            new GemItem("anotherTest", "anotherDescription", ItemData.ItemRarity.Rare, 99, 250, 0, GemEffect.Canceling, 1),
            new ItemData("Default", "Default Description", ItemData.ItemRarity.Common, 99, 250, 0)
        };
    }

    //Gets an item by its name
    public ItemData GetItem(string itemName)
    {
        //Loops through each item
        for (int i = 0; i < items.Count; i++)
        {
            //If an items name is equal to the desired itemName
            if (items[i].ItemName == itemName)
            {
                //then return the item
                return items[i];
            }
        }

        Debug.Log($"Couldn't find item with the name: {itemName}!");

        //return null if no items exists with the desired name
        return null;
    }
}