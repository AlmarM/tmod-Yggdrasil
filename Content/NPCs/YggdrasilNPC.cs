using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.NPCs;

public abstract class YggdrasilNPC : ModNPC
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());
}