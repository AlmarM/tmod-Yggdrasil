using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class HagalazEffect : RuneEffect<HagalazEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters damageParams = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.HagalazEffectDescription, damageParams.MagicDamageBonus);
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