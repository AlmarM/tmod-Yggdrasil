using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;

namespace Yggdrasil;

public class YggdrasilKeybinds : ModSystem
{
    public static ModKeybind LanceStance { get; private set; }

    public override void Load()
    {
        LanceStance = KeybindLoader.RegisterKeybind(Mod, "Lance Stance", Keys.C);
    }

    public override void Unload()
    {
        LanceStance = null;
    }
}