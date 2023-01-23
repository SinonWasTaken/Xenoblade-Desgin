using NekinuSoft;

namespace Xenoblade_Remake.ShopSystem
{
    public class ShopSystem : Component
    {
        private ShopCategory[] categories;

        public override void Awake()
        {
            categories = new ShopCategory[4];
        }

        public ShopCategory[] Categories => categories;
    }
}