using Terraria;
using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Effects;

public class ThurisazEffect : RuneEffect<ThurisazEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters thornsParameters = CastParameters(effectParameters);
        string percentage = TextUtils.GetPercentage(thornsParameters.ThornsBonus);

        return MakeDescription(RuneEffectConfig.ThurisazEffectDescription, percentage);
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