using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Placeable
{
	public class ColdIronBar : YggdrasilItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 59; // influences the inventory sort order. 59 is PlatinumBar, higher is more valuable.
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
			Item.createTile = ModContent.TileType<Tiles.ColdIronBarTile>();
			Item.placeStyle = 0;
			Item.rare = ItemRarityID.Lime;
		}

		public override void AddRecipes() => CreateRecipe()
		.AddIngredient(Mod, "ColdIronOre", 6)
		.AddIngredient(ItemID.ChlorophyteBar)
		.AddTile(TileID.Furnaces)
		.Register();

	}
}
