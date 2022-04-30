using System.Linq;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Runic;

public class AutoReuseEffect : RunicEffect
{
    public AutoReuseEffect(int runePower) : base(runePower)
    {
    }

    protected override string GetDescription()
    {
        return "Enables auto swing";
    }

    public static bool Apply(AutoReuseEffect[] effects, RunePlayer runePlayer)
    {
        return effects.Any(e => runePlayer.RunePower >= e.RunePowerRequired);
    }
}