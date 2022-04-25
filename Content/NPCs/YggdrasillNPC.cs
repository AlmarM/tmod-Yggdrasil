using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.NPCs;

public abstract class YggdrasillNPC : ModNPC
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());
}