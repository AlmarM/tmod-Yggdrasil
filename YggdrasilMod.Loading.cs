using Terraria.ModLoader;

namespace Yggdrasil;

public partial class YggdrasilMod : Mod
{
    public override void Unload()
    {
        Instances.Dispose();
    }
}