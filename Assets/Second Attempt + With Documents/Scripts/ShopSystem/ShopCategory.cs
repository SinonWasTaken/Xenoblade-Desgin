using System.Collections.Generic;
using Xenoblade_Remake.Item;

public class ShopCategory
{
    private ShopPages page;
    private List<ItemData> items;

    public ShopCategory(ShopPages page, params ItemData[] items)
    {
        this.items = new List<ItemData>();
        this.items.AddRange(items);
    }

    public ShopPages Page => page;
    public List<ItemData> Items => items;
}