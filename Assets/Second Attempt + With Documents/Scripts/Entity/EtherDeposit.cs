using Xenoblade_Remake.Entity;
using Xenoblade_Remake.Scripts;

namespace Xenoblade_Remake;

public class EtherDeposit : WorldEntity, InteractiveEntity
{
    private int etherToGive;
    
    public EtherDeposit(string entityName) : base(entityName)
    {
    }

    public void Interact(PlayerClass.Player player)
    {
        player.GiveEther(etherToGive);
    }
    //Create a method that calls Interact when the player interacts with this Deposit
}