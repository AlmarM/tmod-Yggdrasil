using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials.Svartalvheim;
using Yggdrasil.Content.Tiles.Furniture.SvartalvheimFurniture;

namespace Yggdrasil.Content.Items.Furniture.Svartalvheim;

public class SvartalvheimChair : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Svartalvheim Chair");

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
        Item.createTile = ModContent.TileType<SvartalvheimChairTile>();
        Item.rare = ItemRarityID.White;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<SvartalvheimStone>(4)
        .AddTile(TileID.WorkBenches)
        .Register();
}