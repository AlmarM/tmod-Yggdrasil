using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Players;
using Terraria.GameContent.Creative;

namespace Yggdrasil.Items.Accessories
{
	public class RunemasterEmblem : YggdrasilItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault ("Runemaster Emblem");
			Tooltip.SetDefault("15% increased [c/ae804f:runic] damage");
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.rare = ItemRarityID.LightRed;
			Item.accessory = true;
			Item.value = Item.buyPrice(0, 2, 0, 0);
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage<RunicDamageClass>() += 0.15f;
		}
			
	}
}