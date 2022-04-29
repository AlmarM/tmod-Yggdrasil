using Terraria.GameContent.Creative;
using Terraria.ID;

namespace Yggdrasil.Content.Items.Materials;

public class Linnen : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Linnen");
        Tooltip.SetDefault("A piece of fabric");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
    }

    public override void SetDefaults()
    {
        Item.maxStack = 999;
        Item.rare = ItemRarityID.White;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.Cobweb, 3)
        .AddTile(TileID.Loom)
        .Register();
}