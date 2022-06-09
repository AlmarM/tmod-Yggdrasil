using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;

namespace Yggdrasil.Content.Projectiles;

public class RuneStoneProjectile : YggdrasilProjectile
{
    public override void SetDefaults()
    {
        // Can the Projectile collide with tiles?
        Projectile.tileCollide = true;
        Projectile.friendly = true;
        Projectile.timeLeft = 18;
        Projectile.DamageType = ModContent.GetInstance<RunicDamageClass>();
        Projectile.alpha = 255;
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.Kill();
        return true;
    }

    public override void AI()
    {
       Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Tin, Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1.5f);
        d.noGravity = true;
    }

}