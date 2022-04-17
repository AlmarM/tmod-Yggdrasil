using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class RaidhoEffect : RuneEffect<RaidhoEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters damageParameters = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.RaidhoEffectDescription, damageParameters.DamageBonus);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters damageParameters = CastParameters(effectParameters);
        player.GetDamage(DamageClass.Throwing) += damageParameters.DamageBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float damageBonus)
        {
            DamageBonus = damageBonus;
        }

        public float DamageBonus { get; }
    }
}