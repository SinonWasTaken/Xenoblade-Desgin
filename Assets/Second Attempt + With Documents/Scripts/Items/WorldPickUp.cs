using System;
using Xenoblade_Remake.Item;

public class WorldPickUp
{
    private DropTable table;

    public WorldPickUp(params DropItem[] items)
    {
        Random random = new Random();
        table = new DropTable(random.Next(1, 3), items);
    }

    public void OnTriggerEnter()
    {
        //Gets the item from the database
        
        
        //Gives the player the item 
        //Player.GiveItem(item, amountToGive)
    }
}