using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class EhwazEffect : RuneEffect<EhwazEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters speedParams = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.EhwazEffectDescription, speedParams.MovementSpeedBonus);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters speedParams = CastParameters(effectParameters);
        player.moveSpeed += speedParams.MovementSpeedBonus;
        player.maxRunSpeed *= 1f + speedParams.MaxSpeedBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float movementSpeedBonus, float maxSpeedBonus)
        {
            MovementSpeedBonus = movementSpeedBonus;
            MaxSpeedBonus = maxSpeedBonus;
        }

        public float MovementSpeedBonus { get; }

        public float MaxSpeedBonus { get; }
    }
}