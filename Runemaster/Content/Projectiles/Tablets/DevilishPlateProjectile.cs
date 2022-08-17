using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class DevilishPlateProjectile : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Projectile.timeLeft = 40;
        Projectile.alpha = 255;
        Projectile.tileCollide = false;
    }

    public override void AI()
    {
        var velocityX = Projectile.velocity.X / 2f;
        var velocityY = Projectile.velocity.Y / 2f;

        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Shadowflame,
            velocityX, velocityY, 0, default, 1.5f);
        d.noGravity = true;
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.ShadowFlame, TimeUtils.SecondsToTicks(4));
    }
}