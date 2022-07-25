using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture.NordicWoodFurniture;
using Yggdrasil.Nordic.Content.Items.Blocks;

namespace Yggdrasil.Nordic.Content.Items.Decorations;

public class NordicWoodWorkbench : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Nordic Wood Work Bench");

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
        Item.createTile = ModContent.TileType<NordicWoodWorkbenchTile>();
        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(0, 0, 0, 30);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NordicWood>(5)
        .Register();
}