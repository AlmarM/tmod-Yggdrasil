using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class IsaEffect : RuneEffect<IsaEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters parameters = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.IsaEffectDescription,
            parameters.DamageBonus,
            parameters.HealthThreshold);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters parameters = CastParameters(effectParameters);

        if (player.statLife < parameters.HealthThreshold * player.statLifeMax2)
        {
            player.GetDamage(DamageClass.Generic) += parameters.DamageBonus;
        }
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float damageBonus, float healthThreshold)
        {
            DamageBonus = damageBonus;
            HealthThreshold = healthThreshold;
        }

        public float DamageBonus { get; }

        public float HealthThreshold { get; }
    }
}