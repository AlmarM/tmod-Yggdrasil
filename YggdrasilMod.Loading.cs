using Terraria.ModLoader;

namespace Yggdrasil;

public partial class YggdrasilMod : Mod
{
    public override void Load()
    {
        Instances.Create();
    }

    public override void Unload()
    {
        Instances.Dispose();
    }
}