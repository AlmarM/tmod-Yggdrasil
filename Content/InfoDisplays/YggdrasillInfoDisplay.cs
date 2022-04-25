using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.InfoDisplays;

public abstract class YggdrasillInfoDisplay : InfoDisplay
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());
}