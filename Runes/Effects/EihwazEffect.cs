using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Effects;

public class EihwazEffect : RuneEffect<EihwazEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters damageParams = CastParameters(effectParameters);
        string percentage = TextUtils.GetPercentage(damageParams.MeleeDamageBonus);

        return MakeDescription(RuneEffectConfig.EihwazEffectDescription, percentage);
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