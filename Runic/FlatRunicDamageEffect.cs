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
        return $"Grants +{FlatDamage} {RuneConfig.ColoredRunicDamageLabel} damage";
    }

    public static void Apply(FlatRunicDamageEffect[] effects, RunePlayer runePlayer, ref StatModifier damage)
    {
        foreach (FlatRunicDamageEffect effect in effects)
        {
            if (runePlayer.RunePower >= effect.RunePowerRequired)
            {
                damage.Flat += effect.FlatDamage;
            }
        }
    }
}