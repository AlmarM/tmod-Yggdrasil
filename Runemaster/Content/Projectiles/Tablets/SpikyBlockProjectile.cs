using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Projectiles;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class SpikyBlockProjectile : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();
        
        Projectile.timeLeft = 27;
        Projectile.alpha = 255;
    }

    public override void AI()
    {
        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Stone,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1.5f);
        d.noGravity = true;
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        Player player = Main.player[Projectile.owner];

        if (Main.rand.NextFloat() < .10f)
        {
            // @todo clean up in the future
            var x = player.Center.X;
            var y = player.Center.Y;

            int spikeDamage = (damage / 3);

            var direction = target.Center - player.Center;
            direction.Normalize();

            var speed = 6f;
            float speedX = direction.X * speed;
            float speedY = direction.Y * speed;
            int projectileType = ProjectileID.SpikyBall;

            Projectile.NewProjectile(null, x, y, speedX, speedY, projectileType, spikeDamage, 0,
                player.whoAmI);
        }
    }
}