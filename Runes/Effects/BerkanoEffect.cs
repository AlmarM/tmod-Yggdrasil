using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class BerkanoEffect : RuneEffect<BerkanoEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters regenParams = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.BerkanoEffectDescription, regenParams.LifeRegen, regenParams.ManaRegen);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters regenParams = CastParameters(effectParameters);
        player.lifeRegen += regenParams.LifeRegen;
        player.manaRegen += regenParams.ManaRegen;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(int lifeRegen, int manaRegen)
        {
            LifeRegen = lifeRegen;
            ManaRegen = manaRegen;
        }

        public int LifeRegen { get; }

        public int ManaRegen { get; }
    }
}