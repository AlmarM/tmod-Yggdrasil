using Terraria;
using Terraria.ID;
using Yggdrasil.Utils;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public class LunarMemorialSolarProjectile : RuneTabletProjectile
{
    public override void SetDefaults()
    {
        base.SetDefaults();

        Projectile.timeLeft = TimeUtils.SecondsToTicks(2);
        Projectile.tileCollide = false;
    }

    public override void AI()
    {
        Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare,
            Projectile.velocity.X / 2, Projectile.velocity.Y / 2, 0, default, 1.5f);
        d.noGravity = true;

        Lighting.AddLight(Projectile.position, 0.5f, 0.25f, 0.1f);
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.Oiled, TimeUtils.SecondsToTicks(3));
        target.AddBuff(BuffID.OnFire, TimeUtils.SecondsToTicks(3));
    }

    public override void Kill(int timeLeft)
    {
        for (int i = 0; i < 12; i++)
        {
            int num = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare, 0f, -2f,
                0, default, 2f);
            Main.dust[num].noGravity = true;
            Main.dust[num].position.X += Main.rand.Next(-50, 51) * .05f - 1.5f;
            Main.dust[num].position.X += Main.rand.Next(-50, 51) * .05f - 1.5f;
            if (Main.dust[num].position != Projectile.Center)
            {
                Main.dust[num].velocity = Projectile.DirectionTo(Main.dust[num].position) * 2.5f;
            }
        }
    }
}