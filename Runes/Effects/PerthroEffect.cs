using Terraria;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Effects;

public class PerthroEffect : RuneEffect<PerthroEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters buffParameters = CastParameters(effectParameters);
        string percentage = TextUtils.GetPercentage(buffParameters.ApplyBuffChance);

        return MakeDescription(RuneEffectConfig.PerthroEffectDescription, percentage, buffParameters.BuffDuration);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters buffParameters = CastParameters(effectParameters);

        var runePlayer = player.GetModPlayer<RunePlayer>();
        runePlayer.ApplyRandomBuffChance += buffParameters.ApplyBuffChance;
        runePlayer.RandomBuffDuration += buffParameters.BuffDuration;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float applyBuffChance, float buffDuration)
        {
            ApplyBuffChance = applyBuffChance;
            BuffDuration = buffDuration;
        }

        public float ApplyBuffChance { get; }

        public float BuffDuration { get; }
    }
}