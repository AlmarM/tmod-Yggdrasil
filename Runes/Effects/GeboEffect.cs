using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class GeboEffect : RuneEffect<GeboEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters damageParams = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.GeboEffectDescription, damageParams.MinionDamageBonus);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters damageParams = CastParameters(effectParameters);
        player.GetDamage(DamageClass.Summon) += damageParams.MinionDamageBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float minionDamageBonus)
        {
            MinionDamageBonus = minionDamageBonus;
        }

        public float MinionDamageBonus { get; }
    }
}