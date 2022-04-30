using System.Linq;
using Terraria;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Runic;

public class AutoReuseEffect : RunicEffect
{
    public AutoReuseEffect(int runePower) : base(runePower)
    {
    }

    protected override string GetDescription()
    {
        return $"Enables auto swing";
    }

    public static void Apply(AutoReuseEffect[] effects, RunePlayer runePlayer, Item item)
    {
        item.autoReuse = effects.Any(e => runePlayer.RunePower >= e.RunePowerRequired);
    }
}