using Terraria.Audio;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;

namespace Yggdrasil.Content.Projectiles.RuneTablets;

public class LunarMemorialVortexProjectile : RunicProjectile
{
    public override void SetDefaults()
    {
		Projectile.tileCollide = false;
        Projectile.friendly = true;
        Projectile.timeLeft = 30;
        Projectile.DamageType = ModContent.GetInstance<RunicDamageClass>();
        //Projectile.alpha = 255;
		Projectile.penetrate = 10;
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.Kill();
        return true;
    }

    public override void AI()
    {
        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Vortex, Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1.5f);
        d.noGravity = true;

        Lighting.AddLight(Projectile.position, 0.05f, 0.45f, 0.2f);
    }

    public override void Kill(int timeLeft)
	{
		SoundEngine.PlaySound(SoundID.Item69, Projectile.position);

		for (int k = 0; k < 15; k++)
		{
			Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.LunarOre, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
		}
		for (int h = 0; h < 5; h++)
		{
			Vector2 vel = new Vector2(0, -1);
			float rand = Main.rand.NextFloat() * (float)Math.PI;
			vel = vel.RotatedBy(rand);
			vel *= 6f;
			Projectile.NewProjectile(null, Projectile.Center.X, Projectile.Center.Y + 20, vel.X, vel.Y, ModContent.ProjectileType<LunarMemorialVortexProjectileExplode>(), (Projectile.damage * 2), 0, Projectile.owner);
		}

		for (int i = 0; i < 10; i++)
		{
			int num = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Vortex, 0f, -2f, 0, default, 2f);
			Main.dust[num].noGravity = true;
			Main.dust[num].position.X += Main.rand.Next(-50, 51) * .05f - 1.5f;
			Main.dust[num].position.X += Main.rand.Next(-50, 51) * .05f - 1.5f;
			if (Main.dust[num].position != Projectile.Center)
			{
				Main.dust[num].velocity = Projectile.DirectionTo(Main.dust[num].position) * 1.5f;
			}
		}
	}

}