using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Accessories
{
	public class NorsemanShield : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault ("Norsemen Shield");
			Tooltip.SetDefault("Grants immunity to knockback"+
				"\nGrant + 3 defense"+
				"\nIncrease [c/ae804f:Runic] damage by 1");
				
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.rare = ItemRarityID.Orange;
			Item.accessory = true;
			Item.value = Item.buyPrice(0, 2, 0, 0);
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)	
		{
			player.noKnockback = true;
			player.statDefense += 3;
			//player.GetDamage<RunicDamageClass>() += 1;
			
		}
		
	}
}