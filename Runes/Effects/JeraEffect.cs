using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class JeraEffect : RuneEffect<JeraEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters aggroParameters = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.JeraEffectDescription, aggroParameters.AggroReduceBonus);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters aggroParameters = CastParameters(effectParameters);
        player.aggro -= aggroParameters.AggroReduceBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(int aggroReduceBonus)
        {
            AggroReduceBonus = aggroReduceBonus;
        }

        public int AggroReduceBonus { get; }
    }
}