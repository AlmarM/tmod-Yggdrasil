using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Projectiles;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class EvilRockProjectile : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();
            
        Projectile.timeLeft = 27;
        Projectile.alpha = 255;
    }

    public override void AI()
    {
        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.DemonTorch,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 2f);
        d.noGravity = true;
    }
}