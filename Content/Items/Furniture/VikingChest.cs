using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Furniture;

public class VikingChest : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Viking chest");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.maxStack = 99;
        Item.useTurn = true;
        Item.autoReuse = true;
        Item.useAnimation = 15;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.consumable = true;
        Item.value = Item.sellPrice(0, 0, 5);
        Item.createTile = ModContent.TileType<VikingChestTile>();
    }

    public override void AddRecipes() => CreateRecipe()
            .AddIngredient<NordicWood>(5)
            .AddIngredient<FrostCoreBar>(1)
            .AddTile(TileID.WorkBenches)
            .Register();
}