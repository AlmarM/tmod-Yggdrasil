using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Tiles;

namespace Yggdrasil.Content.Items.Materials;

public class NordicWood : YggdrasilItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Nordic Wood");
		Tooltip.SetDefault("Imported from the north");

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
		Item.createTile = ModContent.TileType<NordicWoodTile>();
		Item.placeStyle = 0;
		Item.rare = ItemRarityID.White;
	}

	public override void AddRecipes() => CreateRecipe()
		.AddIngredient(ItemID.BorealWood)
		.AddIngredient(ItemID.SnowBlock)
		.AddTile(TileID.WorkBenches)
		.Register();
}

