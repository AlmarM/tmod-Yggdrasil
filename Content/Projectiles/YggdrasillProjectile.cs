using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Projectiles;

public class YggdrasillProjectile : ModProjectile
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());
}