using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Tiles;

namespace Yggdrasil.Content.Items.Materials;

public class FrostCoreBar : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Frostcore Bar");
        Tooltip.SetDefault("Really cold");

        ItemID.Sets.SortingPriorityMaterials[Item.type] = 59;

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
    }

    public override void SetDefaults()
    {
        Item.maxStack = 999;
        Item.value = 750;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 10;
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<FrostCoreBarTile>();
        Item.placeStyle = 0;
        Item.rare = ItemRarityID.Blue;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostEssence>()
        .AddIngredient<FrostCoreOre>(4)
        .AddTile(TileID.Furnaces)
        .Register();
}