using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class GlacierChunkProjectile : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();
        
        Projectile.timeLeft = 33;
        Projectile.alpha = 255;
    }

    public override void AI()
    {
        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.NorthPole,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1.5f);
        d.noGravity = true;

        Lighting.AddLight(Projectile.position, 0, 0.4f, 0.4f);
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.Frostburn, TimeUtils.SecondsToTicks(2));
    }
}