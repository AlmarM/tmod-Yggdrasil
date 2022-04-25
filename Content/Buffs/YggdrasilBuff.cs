using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Buffs;

public abstract class YggdrasilBuff : ModBuff
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());
}