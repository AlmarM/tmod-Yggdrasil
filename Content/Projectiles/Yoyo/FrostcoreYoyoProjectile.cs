using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Yggdrasil.Content.Projectiles.Yoyo;

public class FrostcoreYoyoProjectile : YggdrasilProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Frostcore Yoyo Projectile");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.CloneDefaults(ProjectileID.Valor);
		Projectile.damage = 21;
		Projectile.extraUpdates = 1;
		AIType = ProjectileID.Valor;
	}

	public override void AI()
	{
		Vector2 position = Projectile.Center + Vector2.Normalize(Projectile.velocity) * 2;
		Projectile.velocity.X *= 1.005f;
		Dust newDust = Main.dust[Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.NorthPole, 0f, 0f, 0, default(Color), 1f)];
		newDust.position = position;
		newDust.velocity = Projectile.velocity.RotatedBy(Math.PI / 2, default(Vector2)) * 0.33F + Projectile.velocity / 4;
		newDust.position += Projectile.velocity.RotatedBy(Math.PI / 2, default(Vector2));
		newDust.fadeIn = 0.5f;
		newDust.noGravity = true;
	}

	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		if (Main.rand.NextFloat() < .5f)
		{
			target.AddBuff(BuffID.Frostburn, 180);
		}
	}
}