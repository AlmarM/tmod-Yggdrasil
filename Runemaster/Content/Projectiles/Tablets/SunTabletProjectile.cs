using Terraria;
using Terraria.ID;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class SunTabletProjectile : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Projectile.timeLeft = 45;
        Projectile.alpha = 255;
        Projectile.tileCollide = false;
    }

    public override void AI()
    {
        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 3f);
        d.noGravity = true;
    }
}