using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Furniture;

public class DvergrPowerForge : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Dvergr Power Forge");

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
        Item.value = 500;
        Item.createTile = ModContent.TileType<DvergrPowerForgeTile>();
        Item.rare = ItemRarityID.Orange;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient<DvergrForge>()
        .AddIngredient<GlacierShards>(10)
        .AddIngredient(ItemID.MythrilAnvil)
        .AddTile(TileID.TinkerersWorkbench)
        .Register();

        CreateRecipe()
        .AddIngredient<DvergrForge>()
        .AddIngredient<GlacierShards>(10)
        .AddIngredient(ItemID.OrichalcumAnvil)
        .AddTile(TileID.TinkerersWorkbench)
        .Register();
    }
}