using Yggdrasil.Players.Modifiers;

namespace Yggdrasil;
public class Instances
{
    public static PlayerModifierCache PlayerModifierCache { get; private set; }

    public static void Create()
    {
        PlayerModifierCache = new PlayerModifierCache();
    }

    public static void Dispose()
    {
        PlayerModifierCache = null;
    }
}