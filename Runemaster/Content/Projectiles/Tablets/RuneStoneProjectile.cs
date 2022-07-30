using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Projectiles;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class RuneStoneProjectile : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();
        
        Projectile.timeLeft = 18;
        Projectile.alpha = 255;
    }

    public override void AI()
    {
        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Tin,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1.5f);
        d.noGravity = true;
    }
}