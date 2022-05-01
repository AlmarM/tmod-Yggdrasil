using Yggdrasil.Configs;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Runic;

public class RunicCritChanceEffect : RunicEffect
{
    public int CritBonus { get; }

    public RunicCritChanceEffect(int runePower, int critBonus) : base(runePower)
    {
        CritBonus = critBonus;
    }

    protected override string GetDescription()
    {
        return $"Grants +{CritBonus}% {RuneConfig.RunicDamageTooltip} crit chance";
    }

    public static void Apply(RunicCritChanceEffect[] effects, RunePlayer runePlayer, ref float crit)
    {
        foreach (RunicCritChanceEffect effect in effects)
        {
            if (runePlayer.RunePower >= effect.RunePowerRequired)
            {
                crit += effect.CritBonus;
            }
        }
    }
}