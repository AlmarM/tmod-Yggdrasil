using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;
using Yggdrasil.Content.Buffs;

namespace Yggdrasil.Content.Projectiles;

public class FrostCoreArrowProjectile : YggdrasilProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("FrostCore Arrow");
	}

	public override void SetDefaults()
	{
		Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
		//Projectile.damage = 15;
		Projectile.extraUpdates = 1;
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		AIType = ProjectileID.WoodenArrowFriendly;
	}
	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		target.AddBuff(BuffID.Frostburn, 180);
		target.AddBuff(ModContent.BuffType<SlowDebuff>(), 30);
	}

	public override void Kill(int timeLeft)
	{
		for (int i = 0; i < 5; i++)
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Frost);
		}
		SoundEngine.PlaySound(SoundID.Dig, (int)Projectile.position.X, (int)Projectile.position.Y);
	}



}