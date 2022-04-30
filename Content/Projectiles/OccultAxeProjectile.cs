using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.DamageClasses;

namespace Yggdrasil.Content.Projectiles;

public class OccultAxeProjectile : YggdrasilProjectile
{
    public override void SetDefaults()
    {
        Projectile.CloneDefaults(ProjectileID.PaladinsHammerFriendly);

        // Can the Projectile collide with tiles?
        Projectile.tileCollide = false;
        Projectile.friendly = true;
        //Projectile.timeLeft = 600;
        Projectile.DamageType = ModContent.GetInstance<RunicDamageClass>();

        AIType = ProjectileID.PaladinsHammerFriendly;
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.Kill();
        return true;
    }

    public override void Kill(int timeLeft)
    {
        for (var i = 0; i < 5; i++)
        {
            var projectilePosition = Projectile.position + Projectile.velocity;
            var speedX = Projectile.oldVelocity.X * 0.5f;
            var speedY = Projectile.oldVelocity.Y * 0.5f;

            Dust.NewDust(projectilePosition, Projectile.width, Projectile.height, DustID.Dirt, speedX, speedY);
        }

        SoundEngine.PlaySound(SoundID.Item24, Projectile.position);
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
    }
}