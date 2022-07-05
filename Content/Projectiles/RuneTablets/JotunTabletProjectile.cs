using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Players;
using Yggdrasil.DamageClasses;

namespace Yggdrasil.Content.Projectiles.RuneTablets;

public class JotunTabletProjectile : RunicProjectile
{
    public override void SetDefaults()
    {
        // Can the Projectile collide with tiles?
        Projectile.tileCollide = true;
        Projectile.friendly = true;
        Projectile.timeLeft = 33;
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
        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 3f);
        d.noGravity = true;

        Lighting.AddLight(Projectile.position, 0.2f, 0.5f, 0.1f);
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.CursedInferno, 120);
    }

}