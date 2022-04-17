using Terraria;
using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Effects;

public class LaguzEffect : RuneEffect<LaguzEffect.Parameters>
{
    private int _timeLeftOHeal;

    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters healParameters = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.LaguzEffectDescription,
            healParameters.HealthRestored,
            healParameters.HealInterval);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters healthParameters = CastParameters(effectParameters);

        if (player.statLife >= player.statLifeMax2 || --_timeLeftOHeal > 0)
        {
            return;
        }

        _timeLeftOHeal = TimeUtils.SecondsToTicks(healthParameters.HealInterval);

        player.statLife += healthParameters.HealthRestored;
        player.HealEffect(healthParameters.HealthRestored);
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(int healthRestored, float healInterval)
        {
            HealthRestored = healthRestored;
            HealInterval = healInterval;
        }

        public int HealthRestored { get; }

        public float HealInterval { get; }
    }
}