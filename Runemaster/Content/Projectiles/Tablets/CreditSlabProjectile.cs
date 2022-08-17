using Terraria;
using Terraria.ID;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class CreditSlabProjectile : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Projectile.timeLeft = 40;
        Projectile.tileCollide = false;
    }

    public override void AI()
    {
        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GoldCoin,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1.5f);
        d.noGravity = true;

        Lighting.AddLight(Projectile.position, 0.6f, 0.6f, 0.1f);
    }
}