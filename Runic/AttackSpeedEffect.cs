using Yggdrasil.Content.Players;
using Yggdrasil.Utils;

namespace Yggdrasil.Runic;

public class AttackSpeedEffect : RunicEffect
{
    public float SpeedBonus { get; }

    public AttackSpeedEffect(int runePower, float speedBonus) : base(runePower)
    {
        SpeedBonus = speedBonus;
    }

    protected override string GetDescription()
    {
        return $"Increases attack speed by {TextUtils.GetPercentage(SpeedBonus)}%";
    }

    public static float Apply(AttackSpeedEffect[] effects, RunePlayer runePlayer)
    {
        var speedBonus = 0f;

        foreach (AttackSpeedEffect effect in effects)
        {
            if (runePlayer.RunePower >= effect.RunePowerRequired)
            {
                speedBonus += effect.SpeedBonus;
            }
        }

        return speedBonus;
    }
}