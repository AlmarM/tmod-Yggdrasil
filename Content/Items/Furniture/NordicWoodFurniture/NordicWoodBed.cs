using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture.NordicWoodFurniture;

namespace Yggdrasil.Content.Items.Furniture.NordicWoodFurniture;

public class NordicWoodBed : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Nordic Wood Bed");

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
        Item.createTile = ModContent.TileType<NordicWoodBedTile>();
        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(0, 0, 4);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NordicWood>(15)
        .AddIngredient<Linnen>(5)
        .AddTile(TileID.Sawmill)
        .Register();

    
}