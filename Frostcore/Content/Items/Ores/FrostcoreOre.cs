using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items;
using Yggdrasil.Content.Tiles;

namespace Yggdrasil.Frostcore.Content.Items.Ores;

public class FrostcoreOre : YggdrasilItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Frostcore Ore");
        Tooltip.SetDefault("Really cold");

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
        Item.createTile = ModContent.TileType<FrostCoreTile>();
        Item.width = 12;
        Item.height = 12;
        Item.value = Terraria.Item.sellPrice(silver: 2);
        Item.rare = ItemRarityID.Blue;
    }
}