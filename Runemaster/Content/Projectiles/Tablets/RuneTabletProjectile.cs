using Terraria.ModLoader;
using Yggdrasil.Content.Projectiles;

namespace Yggdrasil.Runemaster.Content.Projectiles.Tablets;

public abstract class RuneTabletProjectile : YggdrasilProjectile
{
    public override void SetDefaults()
    {
        Projectile.friendly = true;
        Projectile.DamageType = ModContent.GetInstance<RunicDamageClass>();
    }
}