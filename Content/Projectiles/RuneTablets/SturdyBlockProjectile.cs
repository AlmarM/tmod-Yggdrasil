using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Players;
using Yggdrasil.Runemaster;

namespace Yggdrasil.Content.Projectiles.RuneTablets;

public class SturdyBlockProjectile : RunicProjectile
{
    public override void SetDefaults()
    {
        // Can the Projectile collide with tiles?
        Projectile.tileCollide = false;
        Projectile.friendly = true;
        Projectile.timeLeft = 45;
        Projectile.DamageType = ModContent.GetInstance<RunicDamageClass>();
        //Projectile.alpha = 255;
    }

    public override void SetStaticDefaults()
    {
        Main.projFrames[Projectile.type] = 2;
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.Kill();
        return true;
    }

    public override void AI()
    {
        Projectile.frameCounter++;
        if (Projectile.frameCounter >= 3)
        {
            Projectile.frame++;
            Projectile.frameCounter = 0;
            if (Projectile.frame >= 2)
                Projectile.frame = 0;
        }

        Projectile.rotation = Projectile.velocity.ToRotation() + 1.57f;

        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch, Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1.2f);
        d.noGravity = true;
        d.fadeIn = 0.5f;
        Lighting.AddLight(Projectile.position, 0.55f, 0.05f, 0.6f);
    }

    //public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    //{
    //    target.AddBuff(BuffID.Poisoned, 180);
    //}

}