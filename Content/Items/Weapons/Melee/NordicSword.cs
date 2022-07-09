using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Weapons.FrostCore;

namespace Yggdrasil.Content.Items.Weapons.Melee
{
	public class NordicSword : YggdrasilItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Nordic Sword");
			Tooltip.SetDefault("So cold, they stay in place");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.damage = 110;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.knockBack = 7;
			Item.crit = 1;
			Item.value = Item.sellPrice(0, 10);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useStyle = ItemUseStyleID.Swing; 
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Frostburn, 600);
			target.AddBuff(ModContent.BuffType<SlowDebuff>(), 60);

			const int ExplosionProjectiles = 10;
			var Type = ProjectileID.BallofFrost;

			for (int i = 0; i < ExplosionProjectiles; i++)
			{
				Vector2 Speed = Main.rand.NextVector2Unit();
				Projectile.NewProjectile(null, Main.LocalPlayer.Center, Speed * 10, Type, damage, knockback,
					player.whoAmI);
			}
		}


		public override void AddRecipes() => CreateRecipe()
		.AddIngredient<GlacierSword>()
		.AddIngredient<ColdIronBar>(5)
		.AddTile(TileID.MythrilAnvil)
		.Register();

	}
}
