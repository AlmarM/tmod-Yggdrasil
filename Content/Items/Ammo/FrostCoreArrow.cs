using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Ammo
{
	public class FrostcoreArrow : YggdrasilItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostcore Arrow");
			Tooltip.SetDefault("Apply Frostburn on hit" +
							   "\nSlows down target for half a sec");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(0, 0, 0, 4);

			Item.maxStack = 999;

			Item.damage = 10;
			Item.knockBack = 0;
			Item.ammo = AmmoID.Arrow;

			Item.DamageType = DamageClass.Ranged;
			Item.consumable = true;

			Item.shoot = ModContent.ProjectileType<FrostcoreArrowProjectile>();
			Item.shootSpeed = 5f;
		}

		public override void AddRecipes() => CreateRecipe(10)
			.AddIngredient<FrostcoreBar>(1)
			.Register();
	}
}
