using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Others
{
	public class Linnen : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault ("Linnen");
			Tooltip.SetDefault("A piece of fabric");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
		}

		public override void SetDefaults() 
		{
			Item.maxStack = 999;
			Item.rare = ItemRarityID.White;
		}
		
		public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.Cobweb, 7)
		.AddTile(TileID.Loom)
        .Register();

	}
}