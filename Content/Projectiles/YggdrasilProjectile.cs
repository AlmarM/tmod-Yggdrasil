using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Projectiles;

public abstract class YggdrasilProjectile : ModProjectile
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());
}