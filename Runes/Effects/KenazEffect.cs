using Terraria;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Effects;

public class KenazEffect : RuneEffect<KenazEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters dodgeParameters = CastParameters(effectParameters);
        string percentage = TextUtils.GetPercentage(dodgeParameters.DodgeChanceBonus);

        return MakeDescription(RuneEffectConfig.KenazEffectDescription, percentage);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters dodgeParameters = CastParameters(effectParameters);
        //player.GetModPlayer<RunemasterPlayer>().DodgeChance += dodgeParameters.DodgeChanceBonus;
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