using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Yggdrasil.Content.Items.Materials;

namespace Yggdrasil.Content.Items.Weapons.FrostCore
{
	public class FrostcoreSword : YggdrasilItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Frostcore Sword");
			Tooltip.SetDefault("50% chance to frostburn target for 3 sec");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.damage = 22;
			Item.DamageType = DamageClass.Melee;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.knockBack = 4;
			Item.crit = 0;
			Item.value = Item.sellPrice(0, 0, 23);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useStyle = ItemUseStyleID.Swing; 
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) 
		{
			if (Main.rand.NextFloat() < .5f)
			{
				target.AddBuff(BuffID.Frostburn, 180);
			}
		}

		public override void AddRecipes() => CreateRecipe()
		.AddIngredient<FrostcoreBar>(8)
		.AddTile(TileID.Anvils)
		.Register();

		public override void MeleeEffects(Player player, Rectangle hitbox) 
		{
			
			int dustType = 197;
			int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, dustType);
			Dust dust = Main.dust[dustIndex];
			dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
			dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
			dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			
		}

	}
}
