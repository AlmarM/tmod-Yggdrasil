using Terraria;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Runes.Effects;

public class NauthizEffect : RuneEffect<NauthizEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters invincibilityParameters = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.NauthizEffectDescription, invincibilityParameters.InvincibilityBonus);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters invincibilityParameters = CastParameters(effectParameters);
        //player.GetModPlayer<RunemasterPlayer>().InvincibilityBonusTime += invincibilityParameters.InvincibilityBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float invincibilityBonus)
        {
            InvincibilityBonus = invincibilityBonus;
        }

        public float InvincibilityBonus { get; }
    }
}