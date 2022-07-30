using Terraria.ID;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Projectiles;

public abstract class YggdrasilProjectile : ModProjectile
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());

    protected void SetCultistResistance()
    {
        ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
    }
}