using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Accessories
{
	public class RunicSlab : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault ("Runic Slab");
			Tooltip.SetDefault("Display[c/ae804f: Runic Power]");
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.rare = ItemRarityID.Blue;
			Item.accessory = false;
		}
		
		public override void UpdateInventory (Player player)	
		{
			var modPlayer = player.GetModPlayer<YggdrasilPlayer>();
			modPlayer.showRunePower = true;

		}
		
		public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.StoneBlock, 10)
		.AddIngredient(ItemID.Lens)
		.AddTile(TileID.WorkBenches)
        .Register();
		
	}
}