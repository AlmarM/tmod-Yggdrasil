using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class ThurisazEffect : RuneEffect<ThurisazEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters thornsParameters = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.ThurisazEffectDescription, thornsParameters.ThornsBonus);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters thornsParameters = CastParameters(effectParameters);
        player.thorns += thornsParameters.ThornsBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float thornsBonus)
        {
            ThornsBonus = thornsBonus;
        }

        public float ThornsBonus { get; }
    }
}