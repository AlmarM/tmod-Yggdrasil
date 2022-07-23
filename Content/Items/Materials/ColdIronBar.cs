using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Tiles;

namespace Yggdrasil.Content.Items.Materials;

public class ColdIronBar : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        // influences the inventory sort order. 59 is PlatinumBar, higher is more valuable.
        ItemID.Sets.SortingPriorityMaterials[Item.type] = 59;

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
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
        Item.createTile = ModContent.TileType<ColdIronBarTile>();
        Item.placeStyle = 0;
        Item.value = Item.sellPrice(0, 1, 20);
        Item.rare = ItemRarityID.Yellow;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<ColdIronOre>(6)
        .AddTile(TileID.AdamantiteForge)
        .Register();
}