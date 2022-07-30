using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Frostcore.Content.Items.Ores;
using Yggdrasil.Nordic.Content.Items.Blocks;

namespace Yggdrasil.Content.Items.Decorations;

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
        .AddIngredient<FrostcoreBar>(1)
        .AddTile(TileID.WorkBenches)
        .Register();
}