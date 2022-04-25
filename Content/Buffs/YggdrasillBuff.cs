using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public abstract class YggdrasillBuff : ModBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());
}