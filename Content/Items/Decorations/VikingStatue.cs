using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Furniture;

public class VikingStatue : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Viking Statue");

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
        Item.createTile = ModContent.TileType<VikingStatueTile>();
        Item.rare = ItemRarityID.White;
        Item.scale = 0.7f;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.StoneBlock, 50)
        .AddTile(TileID.WorkBenches)
        .Register();
}