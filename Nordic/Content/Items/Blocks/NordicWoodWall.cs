using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture.NordicWoodFurniture;

namespace Yggdrasil.Nordic.Content.Items.Blocks;

public class NordicWoodWall : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("NordicWood Wall");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

        ItemID.Sets.SortingPriorityMaterials[Item.type] = -1;
    }

    public override void SetDefaults()
    {
        Item.maxStack = 999;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 10;
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createWall = ModContent.WallType<NordicWoodWallTile>();
        Item.placeStyle = 0;
        Item.rare = ItemRarityID.White;
    }

    public override void AddRecipes() => CreateRecipe(4)
        .AddIngredient<NordicWood>()
        .AddTile(TileID.WorkBenches)
        .Register();
}