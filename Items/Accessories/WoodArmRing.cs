using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;

namespace Yggdrasil.Items.Accessories
{
	public class WoodArmRing : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault ("Wooden Armring");
			Tooltip.SetDefault("Grants +1 [c/ae804f: Runic Power]");
		}

		public override void SetDefaults() 
		{
			//Item.maxStack = 1;
			Item.rare = ItemRarityID.White;
			Item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<YggdrasilPlayer>().RunePower += 1;
		}
		
		public override void AddRecipes() => CreateRecipe()
        .AddRecipeGroup(RecipeGroupID.Wood, 10)
		.AddTile(TileID.WorkBenches)
        .Register();
		
	}
}