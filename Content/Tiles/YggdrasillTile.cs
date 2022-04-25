using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Tiles;

public abstract class YggdrasillTile : ModTile
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());
}