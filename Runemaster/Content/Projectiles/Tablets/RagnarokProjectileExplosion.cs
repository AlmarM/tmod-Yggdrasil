using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class RagnarokProjectileExplosion : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Projectile.width = 16;
        Projectile.height = 26;
        Projectile.timeLeft = TimeUtils.SecondsToTicks(10);
        Projectile.penetrate = 10;
    }

    public override void SetStaticDefaults()
    {
        SetCultistResistance();

        Main.projFrames[Projectile.type] = 3;
    }

    public override void AI()
    {
        Projectile.frameCounter++;
        if (Projectile.frameCounter >= 4)
        {
            Projectile.frame++;
            Projectile.frameCounter = 0;
            if (Projectile.frame >= 3)
                Projectile.frame = 0;
        }

        Vector2 targetPos = Projectile.Center;
        float targetDist = 1000f;
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
            float homingSpeedFactor = 15f;
            Vector2 homingVect = targetPos - Projectile.Center;
            float dist = Projectile.Distance(targetPos);
            dist = homingSpeedFactor / dist;
            homingVect *= dist;

            Projectile.velocity = (Projectile.velocity * 20 + homingVect) / 21f;
        }

        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.LunarOre,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1f);
        d.noGravity = true;

        Lighting.AddLight(Projectile.position, 0.1f, 0.5f, 0.25f);
    }
}