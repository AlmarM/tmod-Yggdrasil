using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Tiles.IronWood;

namespace Yggdrasil.Content.Items.Materials.IronWood;

public class IronWoodWall : YggdrasilItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Iron Wood Wall");
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
		Item.createWall = ModContent.WallType<IronWoodWallTile>();
		Item.placeStyle = 0;
		Item.rare = ItemRarityID.White;
	}

	public override void AddRecipes() => CreateRecipe()
		.AddIngredient<IronWoodItem>(4)
		.AddTile(TileID.WorkBenches)
		.Register();
}

