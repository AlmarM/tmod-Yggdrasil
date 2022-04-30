using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;

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

    public static void Apply(FlatRunicDamageEffect[] effects, RunePlayer runePlayer, ref StatModifier damage,
        ref float flat)
    {
        foreach (FlatRunicDamageEffect effect in effects)
        {
            if (runePlayer.RunePower >= effect.RunePowerRequired)
            {
                flat += effect.FlatDamage;
            }
        }
    }
}