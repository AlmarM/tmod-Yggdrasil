using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.CheeseMaking.Content.Tiles;
using Yggdrasil.Content.Items;

namespace Yggdrasil.CheeseMaking.Content.Items;

public class FermentingBarrel : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Fermenting Barrel");
    }

    public override void SetDefaults()
    {
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;
        Item.maxStack = 999;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<FermentingBarrelTile>();
        Item.width = 22;
        Item.height = 28;
    }
}