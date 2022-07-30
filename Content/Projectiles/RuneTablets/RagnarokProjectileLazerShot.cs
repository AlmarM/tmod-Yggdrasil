using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Runemaster;

namespace Yggdrasil.Content.Projectiles.RuneTablets;

public class RagnarokProjectileLazerShot : RunicProjectile
{
    public override void SetDefaults()
    {
        Projectile.width = 16;
        Projectile.height = 26;
        Projectile.tileCollide = true;
        Projectile.friendly = true;
        Projectile.timeLeft = 300;
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
        Projectile.frameCounter++;
        if (Projectile.frameCounter >= 4)
        {
            Projectile.frame++;
            Projectile.frameCounter = 0;
            if (Projectile.frame >= 3)
                Projectile.frame = 0;
        }

        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.LunarOre, Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1f);
        d.noGravity = true;

        Lighting.AddLight(Projectile.position, 0.1f, 0.5f, 0.25f);
    }

    public override void Kill(int timeLeft)
    {

        for (int k = 0; k < 15; k++)
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.LunarOre, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
        }
        for (int h = 0; h < 3; h++)
        {
            Vector2 vel = new Vector2(0, -1);
            float rand = Main.rand.NextFloat() * (float)Math.PI;
            vel = vel.RotatedBy(rand);
            vel *= 6f;
            Projectile.NewProjectile(null, Projectile.Center.X, Projectile.Center.Y + 20, vel.X, vel.Y, ModContent.ProjectileType<RagnarokProjectileExplosion>(), (Projectile.damage * 2), 0, Projectile.owner);
        }
    }

}