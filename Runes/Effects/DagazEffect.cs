using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class DagazEffect : RuneEffect<DagazEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters damageParams = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.DagazEffectDescription, damageParams.RangeDamageBonus);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters damageParams = CastParameters(effectParameters);
        player.GetDamage(DamageClass.Ranged) += damageParams.RangeDamageBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float rangeDamageBonus)
        {
            RangeDamageBonus = rangeDamageBonus;
        }

        public float RangeDamageBonus { get; }
    }
}