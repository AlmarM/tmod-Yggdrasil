using Terraria;
using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Effects;

public class TiwazEffect : RuneEffect<TiwazEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters damageParameters = CastParameters(effectParameters);
        string percentage = TextUtils.GetPercentage(damageParameters.RunicDamageBonus);

        return MakeDescription(RuneEffectConfig.TiwazEffectDescription, percentage);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters damageParameters = CastParameters(effectParameters);
        // add runic damage
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float runicDamageBonus)
        {
            RunicDamageBonus = runicDamageBonus;
        }

        public float RunicDamageBonus { get; }
    }
}