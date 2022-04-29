using Yggdrasil.Configs;

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
}