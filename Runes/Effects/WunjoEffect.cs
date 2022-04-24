using Terraria;
using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Effects;

public class WunjoEffect : RuneEffect<WunjoEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters reductionParameters = CastParameters(effectParameters);
        string percentage = TextUtils.GetPercentage(reductionParameters.DamageReductionBonus);

        return MakeDescription(RuneEffectConfig.WunjoEffectDescription, percentage);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters reductionParameters = CastParameters(effectParameters);
        player.endurance += reductionParameters.DamageReductionBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float damageReductionBonus)
        {
            DamageReductionBonus = damageReductionBonus;
        }

        public float DamageReductionBonus { get; }
    }
}