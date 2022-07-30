using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Tiles.Furniture.NordicWoodFurniture;
using Yggdrasil.Nordic.Content.Items.Blocks;

namespace Yggdrasil.Nordic.Content.Items.Decorations;

public class NordicWoodTable : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Nordic Wood Table");

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
        Item.createTile = ModContent.TileType<NordicWoodTableTile>();
        Item.rare = ItemRarityID.White;
        Item.value = Item.sellPrice(0, 0, 0, 60);
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NordicWood>(8)
        .AddTile(TileID.WorkBenches)
        .Register();
}