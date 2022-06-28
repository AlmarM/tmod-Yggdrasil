using Yggdrasil.Runes.Effects;

namespace Yggdrasil;

internal static class Instances
{
    public static void Create()
    {
    }

    public static void Dispose()
    {
        RuneEffects.Dispose();
    }
}