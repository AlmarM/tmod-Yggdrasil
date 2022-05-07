using Terraria.GameContent.Creative;
using Terraria.ID;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Others;

public class VikingKey : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Viking Key");
        Tooltip.SetDefault("A cold key");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.maxStack = 999;
        Item.rare = ItemRarityID.White;
    }

    //Temporary
    /*public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FrostcoreBar>(5)
        .AddIngredient(ItemID.IceBlock, 50)
        .AddTile(TileID.Bottles)
        .Register();*/
}