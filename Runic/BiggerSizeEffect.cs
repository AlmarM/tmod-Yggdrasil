using Terraria;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;

namespace Yggdrasil.Runic;

public class BiggerSizeEffect : RunicEffect
{
    public float SizeBonus { get; }

    public BiggerSizeEffect(int runePower, float sizeBonus) : base(runePower)
    {
        SizeBonus = sizeBonus;
    }

    protected override string GetDescription()
    {
        return $"Increases size by {TextUtils.GetPercentage(SizeBonus)}%";
    }

    public static float Apply(BiggerSizeEffect[] effects, RunePlayer runePlayer, Item item)
    {
        var sizeBonus = 0f;

        foreach (BiggerSizeEffect effect in effects)
        {
            if (runePlayer.RunePower >= effect.RunePowerRequired)
            {
                sizeBonus += effect.SizeBonus;
            }
        }

        return sizeBonus;
    }
}