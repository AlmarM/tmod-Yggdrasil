using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Materials.Svartalvheim;
using Yggdrasil.Content.Tiles.Furniture.SvartalvheimFurniture;

namespace Yggdrasil.Content.Items.Furniture.Svartalvheim;

public class SvartalvheimWorkbench : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("'For a dwarf, it's also a table!'");

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
        Item.createTile = ModContent.TileType<SvartalvheimWorkbenchTile>();
        Item.rare = ItemRarityID.Yellow;
        Item.value = Item.sellPrice(0, 1, 20);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<SvartalvheimStone>(5)
        .AddIngredient<ColdIronBar>()
        .Register();
}