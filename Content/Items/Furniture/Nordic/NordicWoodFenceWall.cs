using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture.NordicWoodFurniture;

namespace Yggdrasil.Content.Items.Furniture.Nordic;

public class NordicWoodFenceWall : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Nordic Wood Fence");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.maxStack = 999;
        Item.useTurn = true;
        Item.autoReuse = true;
        Item.useAnimation = 15;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.consumable = true;
        Item.createWall = ModContent.WallType<NordicWoodFenceWallTile>();
        Item.rare = ItemRarityID.White;
    }

    public override void AddRecipes() => CreateRecipe(4)
        .AddIngredient<NordicWood>()
        .AddTile(TileID.WorkBenches)
        .Register();
}