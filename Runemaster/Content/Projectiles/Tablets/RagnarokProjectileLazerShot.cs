using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class RagnarokProjectileLazerShot : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Projectile.width = 16;
        Projectile.height = 26;
        Projectile.timeLeft = TimeUtils.SecondsToTicks(5);
        Projectile.tileCollide = false;
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

        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.LunarOre,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1f);
        d.noGravity = true;

        Lighting.AddLight(Projectile.position, 0.1f, 0.5f, 0.25f);
    }

    public override void Kill(int timeLeft)
    {
        for (int k = 0; k < 15; k++)
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height,
                DustID.LunarOre, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
        }

        for (int h = 0; h < 3; h++)
        {
            Vector2 vel = new Vector2(0, -1);
            float rand = Main.rand.NextFloat() * (float)Math.PI;
            vel = vel.RotatedBy(rand);
            vel *= 6f;
            Projectile.NewProjectile(null, Projectile.Center.X, Projectile.Center.Y + 20, vel.X, vel.Y,
                ModContent.ProjectileType<RagnarokProjectileExplosion>(), (Projectile.damage * 2), 0, Projectile.owner);
        }
    }
}