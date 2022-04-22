using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Accessories
{
	public class FrostGiantHand : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault ("Frost Giant Hand");
			Tooltip.SetDefault("5% increased [c/ae804f:runic] critical strike chance"+
			"\nCritical hit caused by [c/ae804f:runic] weapons release explosive frost sparks"+ //needs implementation!
			"\nGrants immunity to fire blocks ");
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.rare = ItemRarityID.LightRed;
			Item.accessory = true;
			Item.value = Item.buyPrice(0, 1, 0, 0);
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetCritChance<RunicDamageClass>() += 5;
			player.fireWalk = true;
		}
		
		public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.TitanGlove)
		.AddIngredient(ItemID.FrostDaggerfish)
		.AddTile(TileID.WorkBenches)
        .Register();
	}
}