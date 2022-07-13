using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Projectiles.Ammo;

namespace Yggdrasil.Content.Items.Ammo
{
	public class FrostCoreArrow : YggdrasilItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostcore Arrow");
			Tooltip.SetDefault("Apply Frostburn on hit");

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

			Item.shoot = ModContent.ProjectileType<FrostCoreArrowProjectile>();
			Item.shootSpeed = 5f;
		}

		public override void AddRecipes() => CreateRecipe(10)
			.AddIngredient<FrostCoreBar>(1)
			.AddIngredient<NordicWood>(5)
			.Register();
	}
}
