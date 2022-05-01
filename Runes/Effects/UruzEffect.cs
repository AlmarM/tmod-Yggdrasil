using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Effects;

public class UruzEffect : RuneEffect<UruzEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters speedParameters = CastParameters(effectParameters);
        string percentage = TextUtils.GetPercentage(speedParameters.MeleeSpeedBonus);

        return MakeDescription(RuneEffectConfig.UruzEffectDescription, percentage);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters speedParameters = CastParameters(effectParameters);
        player.GetAttackSpeed(DamageClass.Melee) += speedParameters.MeleeSpeedBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float meleeSpeedBonus)
        {
            MeleeSpeedBonus = meleeSpeedBonus;
        }

        public float MeleeSpeedBonus { get; }
    }
}