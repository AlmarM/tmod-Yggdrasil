using Yggdrasil.Content.Items;
using Terraria.ID;

namespace Yggdrasil.CheeseMaking.Content.Items;

public class MilkBucket : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Milk Bucket");
    }

    public override void SetDefaults()
    {
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 10;
        Item.width = 20;
        Item.height = 20;
        Item.maxStack = 99;
        Item.autoReuse = true;
    }
}