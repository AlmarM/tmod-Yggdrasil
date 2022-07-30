using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Projectiles;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class SturdyBlockProjectile : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();
        
        Projectile.timeLeft = 45;
    }

    public override void SetStaticDefaults()
    {
        Main.projFrames[Projectile.type] = 2;
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

        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1.2f);
        d.noGravity = true;
        d.fadeIn = 0.5f;
        Lighting.AddLight(Projectile.position, 0.55f, 0.05f, 0.6f);
    }
}