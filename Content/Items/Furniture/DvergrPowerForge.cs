using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Furniture;

public class DvergrPowerForge : DvergrForge
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();

        Tooltip.SetDefault("Dvergr Power Forge");
    }

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.value = Item.sellPrice(silver: 15);
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