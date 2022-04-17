using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class EihwazEffect : RuneEffect<EihwazEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters damageParams = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.EihwazEffectDescription, damageParams.MeleeDamageBonus);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters damageParams = CastParameters(effectParameters);
        player.GetDamage(DamageClass.Melee) += damageParams.MeleeDamageBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float meleeDamageBonus)
        {
            MeleeDamageBonus = meleeDamageBonus;
        }

        public float MeleeDamageBonus { get; }
    }
}