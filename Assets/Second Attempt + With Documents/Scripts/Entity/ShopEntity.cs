﻿using NekinuSoft;
using Xenoblade_Remake.Scripts;

namespace Xenoblade_Remake.Entity
{
    public class ShopEntity : Component, InteractiveEntity
    {
        private ShopSystem.ShopSystem shop;
        
        public void Interact(PlayerClass.Player player)
        {
            //Opens the shop menu, giving the shop information to the ui class 'ShopUiHandler'
        }
    }
}