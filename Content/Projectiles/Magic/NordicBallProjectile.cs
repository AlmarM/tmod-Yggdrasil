using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;

namespace Yggdrasil.Content.Projectiles.Magic;

public class NordicBallProjectile : RunicProjectile
{
    public override void SetDefaults()
    {
        // Can the Projectile collide with tiles?
        Projectile.tileCollide = true;
        Projectile.friendly = true;
        Projectile.timeLeft = 300;
        Projectile.DamageType = ModContent.GetInstance<RunicDamageClass>();
        //Projectile.alpha = 255;
    }

    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.Kill();
        return true;
    }


    public override void AI()
    {
        Vector2 targetPos = Projectile.Center;
        float targetDist = 400f;
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
            float homingSpeedFactor = 10f;
            Vector2 homingVect = targetPos - Projectile.Center;
            float dist = Projectile.Distance(targetPos);
            dist = homingSpeedFactor / dist;
            homingVect *= dist;

            Projectile.velocity = (Projectile.velocity * 20 + homingVect) / 21f;
        }

        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.BlueCrystalShard, Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 2f);
        d.noGravity = true;

        Lighting.AddLight(Projectile.position, 0.45f, 0.6f, 0.8f);
    }

    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Item69, Projectile.position);

        for (int h = 0; h < 2; h++)
        {
            Vector2 vel = new Vector2(0, -1);
            float rand = Main.rand.NextFloat() * (float)Math.PI;
            vel = vel.RotatedBy(rand);
            vel *= 6f;
            Projectile.NewProjectile(null, Projectile.Center.X, Projectile.Center.Y + 20, vel.X, vel.Y, ModContent.ProjectileType<NordicBallExplosionProjectile>(), Projectile.damage, 0, Projectile.owner);
        }
    }


    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.Frostburn, 180);
        target.AddBuff(ModContent.BuffType<SlowDebuff>(), 90);  
    }

}