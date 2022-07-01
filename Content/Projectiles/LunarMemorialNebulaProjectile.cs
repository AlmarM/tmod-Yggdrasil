using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;

namespace Yggdrasil.Content.Projectiles;

public class LunarMemorialNebulaProjectile : RunicProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 16;
		Projectile.height = 26;
		Projectile.tileCollide = false;
		Projectile.friendly = true;
		Projectile.timeLeft = 600;
		Projectile.DamageType = ModContent.GetInstance<RunicDamageClass>();
		//Projectile.alpha = 255;
	}

	public override void SetStaticDefaults()
	{
		ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
		Main.projFrames[Projectile.type] = 3;
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		Projectile.Kill();
		return true;
	}

	public override void AI()
	{

		Vector2 targetPos = Projectile.Center;
		float targetDist = 1000f;
		bool targetAcquired = false;

		//loop through first 200 NPCs in Main.npc
		//this loop finds the closest valid target NPC within the range of targetDist pixels
		for (int i = 0; i < 200; i++)
		{
			if (Main.npc[i].CanBeChasedBy(Projectile) && Collision.CanHit(Projectile.Center, 1, 1, Main.npc[i].Center, 1, 1))
			{
				float dist = Projectile.Distance(Main.npc[i].Center);
				if (dist < targetDist)
				{
					targetDist = dist;
					targetPos = Main.npc[i].Center;
					targetAcquired = true;
				}
			}
		}

		//change trajectory to home in on target
		if (targetAcquired)
		{
			float homingSpeedFactor = 15f;
			Vector2 homingVect = targetPos - Projectile.Center;
			float dist = Projectile.Distance(targetPos);
			dist = homingSpeedFactor / dist;
			homingVect *= dist;

			Projectile.velocity = (Projectile.velocity * 20 + homingVect) / 21f;
		}

		Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.UndergroundHallowedEnemies, Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1f);
		d.noGravity = true;

		Lighting.AddLight(Projectile.position, 0.45f, 0.25f, 0.45f);
	}

	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
	{
		target.AddBuff(BuffID.Confused, 120);
	}

	public override void Kill(int timeLeft)
	{
		for (int i = 0; i < 10; i++)
		{
			int num = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.UndergroundHallowedEnemies, 0f, -2f, 0, default, 2f);
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