using Terraria;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Runes.Effects;

public class KenazEffect : RuneEffect<KenazEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters dodgeParameters = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.KenazEffectDescription, dodgeParameters.DodgeChanceBonus);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters dodgeParameters = CastParameters(effectParameters);
        player.GetModPlayer<RunePlayer>().DodgeChance += dodgeParameters.DodgeChanceBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float dodgeChanceBonus)
        {
            DodgeChanceBonus = dodgeChanceBonus;
        }

        public float DodgeChanceBonus { get; }
    }
}