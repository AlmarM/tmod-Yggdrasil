using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Placeable
{
	public class FrostCoreOre : YggdrasilItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("FrostCore Ore");
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
			Item.createTile = ModContent.TileType<Tiles.FrostCoreTile>();
			Item.width = 12;
			Item.height = 12;
			Item.value = 200;
			Item.rare = ItemRarityID.Blue;
		}
	}
}
