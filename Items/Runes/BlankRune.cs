using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Runes
{
	public class BlankRune : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault ("Blank Rune");
			Tooltip.SetDefault("[c/ae804f:A rune with no power.]" +
				"\nUsed to craft powerful runes");
				
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
		}

		public override void SetDefaults() 
		{
			Item.maxStack = 999;
			Item.rare = ItemRarityID.White;
		}		
		
		public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.StoneBlock, 10) 
        .Register();

	}
}