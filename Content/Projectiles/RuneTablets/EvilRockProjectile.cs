using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;

namespace Yggdrasil.Content.Projectiles.RuneTablets;

public class EvilRockProjectile : RunicProjectile
{
    public override void SetDefaults()
    {
        // Can the Projectile collide with tiles?
        Projectile.tileCollide = true;
        Projectile.friendly = true;
        Projectile.timeLeft = 27;
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
       Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.DemonTorch, Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 2f);
        d.noGravity = true;
    }

}