using Xenoblade_Remake.Entity;

public class EtherDeposit : WorldEntity, InteractiveEntity
{
    private int etherToGive;
    
    public EtherDeposit(string entityName) : base(entityName)
    {
    }

    public void Interact(Xenoblade_Remake.PlayerClass.Player player)
    {
        throw new System.NotImplementedException();
    }
    //Create a method that calls Interact when the player interacts with this Deposit
}