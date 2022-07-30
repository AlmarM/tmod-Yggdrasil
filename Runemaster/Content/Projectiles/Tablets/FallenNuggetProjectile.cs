using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class FallenNuggetProjectile : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();
        
        Projectile.timeLeft = 27;
        Projectile.alpha = 255;
    }

    public override void AI()
    {
        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.MeteorHead,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1.5f);
        d.noGravity = true;

        Lighting.AddLight(Projectile.position, .5f, .1f, .05f);
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.OnFire, TimeUtils.SecondsToTicks(2));
    }
}