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
}