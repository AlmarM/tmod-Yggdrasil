using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;

namespace Yggdrasil.Content.Projectiles;

public class FireProjectile : YggdrasilProjectile
{
    public override void SetDefaults()
    {
        // Can the Projectile collide with tiles?
        Projectile.tileCollide = false;
        Projectile.friendly = true;
        Projectile.timeLeft = 120;
        Projectile.DamageType = ModContent.GetInstance<RunicDamageClass>();

       //Projectile.CloneDefaults(ProjectileID.Fireball);
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.Kill();
        return true;
    }

    public override void AI()
    {
        Projectile.rotation += 0.5f * Projectile.direction;

        var velocityX = Projectile.velocity.X * 0.25f;
        var velocityY = Projectile.velocity.Y * 0.25f;

        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, velocityX, velocityY,
            0, default, 1.5f);
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.OnFire, 180);
    }

}