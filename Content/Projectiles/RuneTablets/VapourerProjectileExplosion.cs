using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Runemaster;

namespace Yggdrasil.Content.Projectiles.RuneTablets;

public class VapourerProjectileExplosion : RunicProjectile
{
    public override void SetDefaults()
    {
        // Can the Projectile collide with tiles?
        Projectile.tileCollide = true;
        Projectile.friendly = true;
        Projectile.timeLeft = 300;
        Projectile.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Projectile.alpha = 255;
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
        float targetDist = 300f;
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
            float homingSpeedFactor = 6f;
            Vector2 homingVect = targetPos - Projectile.Center;
            float dist = Projectile.Distance(targetPos);
            dist = homingSpeedFactor / dist;
            homingVect *= dist;

            Projectile.velocity = (Projectile.velocity * 20 + homingVect) / 21f;
        }

        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GreenBlood, Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 2f);
        d.noGravity = true;
    }


    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(ModContent.BuffType<SicknessDebuff>(), 300);
    }

}