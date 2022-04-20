/*using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;

namespace Yggdrasil.Items.Accessories
{
	public class ArmRing : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault ("Armring");
			Tooltip.SetDefault("Increase [c/ae804f: Runic] damage by 2");
		}

		public override void SetDefaults() 
		{
			Item.rare = ItemRarityID.White;
			Item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage<RunicDamageClass>() += 2;
		}
		
		public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ItemID.IronBar, 2)
		.AddTile(TileID.Anvils)
        .Register();
		
		CreateRecipe()
		.AddIngredient(ItemID.LeadBar, 2)
		.AddTile(TileID.Anvils)
        .Register();
		
	}
		
	}
}*/