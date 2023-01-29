using System.Collections.Generic;
using UnityEngine;
using Xenoblade_Remake.Inventory.Item;

namespace Xenoblade_Remake.PlayerClass
{
    public class Player : MonoBehaviour
    {
        public static Player Instance;

        private const int etherbar = 4;
        
        private int etherCount;
        private int etherLevel;
        private PlayerInventory inventory;
        //What party member the player is playing as. noah, mio, etc...
        private PlayerPartyMember playerPartyMember;
        private List<PlayerPartyMember> partyMembers;

        public void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(Instance.gameObject);
            }

            Instance = this;
        }

        //Gives the player ether from an ether source
        public void GiveEther(int etherToGive)
        {
            etherCount += etherToGive;
            while (etherCount > etherbar)
            {
                etherLevel++;
                etherCount -= etherbar;
            }
        }
    }
}