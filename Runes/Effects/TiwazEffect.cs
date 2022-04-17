using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class TiwazEffect : RuneEffect<TiwazEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters damageParameters = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.TiwazEffectDescription, damageParameters.RunicDamageBonus);
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