using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Items;

namespace Yggdrasil.Projectiles
{
	public class OccultAxeProjectile : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.friendly = true;
			Projectile.tileCollide = false; // Can the Projectile collide with tiles?
			//Projectile.timeLeft = 600;
			Projectile.DamageType = ModContent.GetInstance<RunicDamageClass>();
			Projectile.CloneDefaults(ProjectileID.PaladinsHammerFriendly);
			AIType = ProjectileID.PaladinsHammerFriendly;
		}

		public override bool OnTileCollide(Vector2 oldVelocity) 
		{
			Projectile.Kill();
			return true;
		}

		public override void Kill(int timeLeft) {
			for (int k = 0; k < 5; k++) {
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Dirt, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
			}
			SoundEngine.PlaySound(SoundID.Item24, Projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) 
		{

		}
	}
}