using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class DevilishPlateProjectileExplosion : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Projectile.timeLeft = TimeUtils.SecondsToTicks(0.5f);
        Projectile.alpha = 255;
        Projectile.tileCollide = false;
    }

    public override void AI()
    {
        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Granite,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 2f);
        d.noGravity = true;
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.Oiled, TimeUtils.SecondsToTicks(5));
    }
}