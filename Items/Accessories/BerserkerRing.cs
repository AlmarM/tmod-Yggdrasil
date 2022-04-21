using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Accessories
{
	public class BerserkerRing : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault ("Berserker Ring");
			Tooltip.SetDefault("10% increased [c/ae804f:runic] damage"+
			"\n3% increased [c/ae804f:runic] critical strike chance");
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
			Item.value = Item.buyPrice(0, 1, 0, 0);
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage<RunicDamageClass>() += 0.1f;
			player.GetCritChance<RunicDamageClass>() += 3;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(Mod, "ArmRing")
			.AddIngredient(ItemID.VilePowder, 5)
			.AddTile(TileID.Anvils)
			.Register();
			
			CreateRecipe()
			.AddIngredient(Mod, "ArmRing")
			.AddIngredient(ItemID.ViciousPowder, 5)
			.AddTile(TileID.Anvils)
			.Register();
		}
		
	}
}