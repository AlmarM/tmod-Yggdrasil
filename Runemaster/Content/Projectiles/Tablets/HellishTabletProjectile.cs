using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class HellishTabletProjectile : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Projectile.timeLeft = TimeUtils.SecondsToTicks(0.5f);
        Projectile.alpha = 255;
    }

    public override void AI()
    {
        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 3f);
        d.noGravity = true;
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.OnFire, TimeUtils.SecondsToTicks(3));
    }
}