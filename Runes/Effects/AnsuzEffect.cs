using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class AnsuzEffect : RuneEffect<AnsuzEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters maxManaParams = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.AnsuzEffectDescription, maxManaParams.Mana);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters maxManaParams = CastParameters(effectParameters);
        player.statManaMax2 += maxManaParams.Mana;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(int mana)
        {
            Mana = mana;
        }

        public int Mana { get; }
    }
}