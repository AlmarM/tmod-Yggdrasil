using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Buffs;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class VapourerProjectileExplosion : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();
        
        Projectile.timeLeft = TimeUtils.SecondsToTicks(5);
        Projectile.alpha = 255;
    }

    public override void SetStaticDefaults()
    {
        SetCultistResistance();
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
            if (Main.npc[i].CanBeChasedBy(Projectile) &&
                Collision.CanHit(Projectile.Center, 1, 1, Main.npc[i].Center, 1, 1))
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

        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GreenBlood,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 2f);
        d.noGravity = true;
    }


    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(ModContent.BuffType<SicknessDebuff>(), TimeUtils.SecondsToTicks(5));
    }
}