using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Frostcore.Content.Items.Ores;

namespace Yggdrasil.Content.Items.Decorations;

public class DvergrForge : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Dvergr Forge");

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
        Item.createTile = ModContent.TileType<DvergrForgeTile>();
        Item.rare = ItemRarityID.Blue;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient<FrostcoreBar>(5)
            .AddIngredient<FrostEssence>(2)
            .AddIngredient(ItemID.GoldBar, 5)
            .AddTile(TileID.Anvils)
            .Register();

        CreateRecipe()
            .AddIngredient<FrostcoreBar>(5)
            .AddIngredient<FrostEssence>(2)
            .AddIngredient(ItemID.PlatinumBar, 5)
            .AddTile(TileID.Anvils)
            .Register();
    }
}