/*using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Yggdrasil.Content.Projectiles;

namespace Yggdrasil.Content.Items.Ammo;

public class IronWoodSolution : YggdrasilItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Iron Wood Solution");
		Tooltip.SetDefault("Used by the Clentaminator");

		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
	}

	public override void SetDefaults()
	{
		Item.shoot = ModContent.ProjectileType<IronWoodSolutionProjectile>() - ProjectileID.PureSpray;
		Item.ammo = AmmoID.Solution;
		Item.width = 10;
		Item.height = 12;
		Item.value = Item.buyPrice(0, 0, 25);
		Item.rare = ItemRarityID.Orange;
		Item.maxStack = 999;
		Item.consumable = true;
	}
}*/