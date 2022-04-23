using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Placeable
{
	public class FrostCoreBar : YggdrasilItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Really cold");
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 59;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
		}

		public override void SetDefaults()
		{
			Item.maxStack = 999;
			Item.value = 750;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.FrostCoreBarTile>();
			Item.placeStyle = 0;
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes() => CreateRecipe()
		.AddIngredient(Mod, "FrostEssence")
		.AddIngredient(ItemID.MeteoriteBar)
		.AddTile(TileID.Furnaces)
		.Register();
	}
}
