using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class UruzEffect : RuneEffect<UruzEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters speedParameters = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.UruzEffectDescription, speedParameters.MeleeSpeedBonus);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters speedParameters = CastParameters(effectParameters);
        player.meleeSpeed += speedParameters.MeleeSpeedBonus;
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