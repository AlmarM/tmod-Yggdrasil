using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class AlgizEffect : RuneEffect<AlgizEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters defenseParameters = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.AlgizEffectDescription, defenseParameters.Defense);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters defenseParams = CastParameters(effectParameters);
        player.statDefense += defenseParams.Defense;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(int defense)
        {
            Defense = defense;
        }

        public int Defense { get; }
    }
}