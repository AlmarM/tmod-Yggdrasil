using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Tiles.Svartalvheim;

namespace Yggdrasil.Svartalvheim.Content.Items.Blocks;

public class SvartalvheimBrickWall : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Svartalvheim Brick Wall");
        Tooltip.SetDefault("Really hard to break");

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
        Item.createWall = ModContent.WallType<SvartalvheimBrickWallTile>();
        Item.placeStyle = 0;
        Item.rare = ItemRarityID.White;
    }

    public override void AddRecipes() => CreateRecipe(4)
        .AddIngredient<SvartalvheimBrick>()
        .AddTile(TileID.WorkBenches)
        .Register();
}