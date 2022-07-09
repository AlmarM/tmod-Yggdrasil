using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Tiles;
using Yggdrasil.Content.Tiles.IronWood;

namespace Yggdrasil.Content.Items.Materials.IronWood;

public class IronWoodIce : YggdrasilItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Iron Wood Ice");
		Tooltip.SetDefault("Hard to break");

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
		Item.createTile = ModContent.TileType<IronWoodIceTile>();
		Item.placeStyle = 0;
		Item.rare = ItemRarityID.White;
	}
}

