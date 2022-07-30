using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Tiles.Furniture.NordicWoodFurniture;
using Yggdrasil.Nordic.Content.Items.Blocks;

namespace Yggdrasil.Nordic.Content.Items.Decorations;

public class NordicWoodChair : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Nordic Wood Chair");

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
        Item.createTile = ModContent.TileType<NordicWoodChairTile>();
        Item.rare = ItemRarityID.White;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NordicWood>(4)
        .AddTile(TileID.WorkBenches)
        .Register();
}