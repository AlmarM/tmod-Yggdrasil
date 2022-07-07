using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Tiles;

public abstract class YggdrasilWall : ModWall
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());
}