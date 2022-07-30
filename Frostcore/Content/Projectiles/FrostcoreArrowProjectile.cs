using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Yggdrasil.Content.Projectiles;
using Yggdrasil.Utils;

namespace Yggdrasil.Frostcore.Content.Projectiles;

public class FrostcoreArrowProjectile : YggdrasilProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Frostcore Arrow");
    }

    public override void SetDefaults()
    {
        Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
        //Projectile.damage = 15;
        Projectile.extraUpdates = 1;

        AIType = ProjectileID.WoodenArrowFriendly;

        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.Frostburn, TimeUtils.SecondsToTicks(2));
    }

    public override void Kill(int timeLeft)
    {
        for (int i = 0; i < 5; i++)
        {
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Frost);
        }

        SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
    }
}