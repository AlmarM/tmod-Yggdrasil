using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Content.Items;

public abstract class YggdrasilItem : ModItem
{
    public override string Texture => TextureUtils.GetAssetPath(GetType());
    
    
}