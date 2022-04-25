using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public class YggdrasillBuff : ModBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());
}