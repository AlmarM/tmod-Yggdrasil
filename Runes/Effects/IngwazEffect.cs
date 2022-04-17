using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class IngwazEffect : RuneEffect<IngwazEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters healthParams = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.IngwazEffectDescription, healthParams.HealthBonus);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters healthParams = CastParameters(effectParameters);
        player.statLifeMax2 += healthParams.HealthBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(int healthBonus)
        {
            HealthBonus = healthBonus;
        }

        public int HealthBonus { get; }
    }
}