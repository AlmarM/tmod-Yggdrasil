using Yggdrasil.Configs;

namespace Yggdrasil.Runic;

public class FlatRunicDamageEffect : RunicEffect
{
    public int FlatDamage { get; }

    public FlatRunicDamageEffect(int runePower, int flatDamage) : base(runePower)
    {
        FlatDamage = flatDamage;
    }

    protected override string GetDescription()
    {
        return $"Grants +{FlatDamage} {RuneConfig.RunicDamageTooltip} damage";
    }
}