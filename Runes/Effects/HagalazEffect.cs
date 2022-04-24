using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Effects;

public class HagalazEffect : RuneEffect<HagalazEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters damageParams = CastParameters(effectParameters);
        string percentage = TextUtils.GetPercentage(damageParams.MagicDamageBonus);

        return MakeDescription(RuneEffectConfig.HagalazEffectDescription, percentage);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters damageParams = CastParameters(effectParameters);
        player.GetDamage(DamageClass.Magic) += damageParams.MagicDamageBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float magicDamageBonus)
        {
            MagicDamageBonus = magicDamageBonus;
        }

        public float MagicDamageBonus { get; }
    }
}