﻿using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Tiles;
using Yggdrasil.Tiles;

namespace Yggdrasil.Content.Items.Materials;

public class ColdIronOre : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
        
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
    }

    public override void SetDefaults()
    {
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 10;
        Item.autoReuse = true;
        Item.maxStack = 999;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<ColdIronTile>();
        Item.width = 12;
        Item.height = 12;
        Item.value = 800;
        Item.rare = ItemRarityID.Green;
    }
}