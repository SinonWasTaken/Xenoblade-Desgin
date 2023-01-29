using UnityEngine;

namespace Xenoblade_Remake.ShopSystem
{
    public class ShopSystem : MonoBehaviour 
    {
        private ShopCategory[] categories;

        public void Awake()
        {
            categories = new ShopCategory[4];
        }

        public ShopCategory[] Categories => categories;
    }
}