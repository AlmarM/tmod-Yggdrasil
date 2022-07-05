using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;

namespace Yggdrasil.Content.Projectiles.Magic;

public class ValkyrieLightStaffProjectile : YggdrasilProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Valkyrie Light Staff Projectile");
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
    }

    public override void SetDefaults()
    {
        Projectile.width = 14;
        Projectile.height = 34;
        Projectile.tileCollide = true;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.timeLeft = 300;
        Projectile.penetrate = 1;
        AIType = ProjectileID.DeathLaser;
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.Kill();
        return true;
    }


    public override void AI()
    {
        Projectile.rotation = Projectile.velocity.ToRotation() + 1.57f;

        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.MagicMirror, Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1.5f);
        d.noGravity = true;

        //Lighting.AddLight(Projectile.position, .5f, .45f, .05f);
    }


    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

        for (int k = 0; k < 10; k++)
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.MagicMirror, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
        }
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.Ichor, 180);
    }
}