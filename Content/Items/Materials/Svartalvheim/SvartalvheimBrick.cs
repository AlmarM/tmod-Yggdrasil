﻿using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Tiles;
using Yggdrasil.Content.Tiles.Svartalvheim;

namespace Yggdrasil.Content.Items.Materials.Svartalvheim;

public class SvartalvheimBrick : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Svartalvheim Brick");
        Tooltip.SetDefault("Really hard to break");

        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

        ItemID.Sets.SortingPriorityMaterials[Item.type] = -1;
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
        Item.createTile = ModContent.TileType<SvartalvheimBrickTile>();
        Item.placeStyle = 0;
        Item.rare = ItemRarityID.White;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<SvartalvheimStone>(2)
        .AddTile(TileID.Furnaces)
        .Register();
}