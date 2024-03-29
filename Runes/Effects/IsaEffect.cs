using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Effects;

public class IsaEffect : RuneEffect<IsaEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters parameters = CastParameters(effectParameters);
        string damagePercentage = TextUtils.GetPercentage(parameters.DamageBonus);
        string healthPercentage = TextUtils.GetPercentage(parameters.HealthThreshold);

        return MakeDescription(RuneEffectConfig.IsaEffectDescription, damagePercentage, healthPercentage);
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