using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture.NordicWoodFurniture;

namespace Yggdrasil.Content.Items.Furniture.Nordic;

public class NordicWoodBookcase : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Nordic Wood Bookcase");

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
        Item.createTile = ModContent.TileType<NordicWoodBookcaseTile>();
        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(0, 0, 0, 60);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NordicWood>(20)
        .AddIngredient(ItemID.Book, 10)
        .AddTile(TileID.Sawmill)
        .Register();
}