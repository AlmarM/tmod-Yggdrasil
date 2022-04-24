using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Effects;

public class FehuEffect : RuneEffect<FehuEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters critParams = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.FehuEffectDescription, critParams.CritChanceBonus);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters critParams = CastParameters(effectParameters);
        player.GetCritChance(DamageClass.Generic) += critParams.CritChanceBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(int critChanceBonus)
        {
            CritChanceBonus = critChanceBonus;
        }

        public int CritChanceBonus { get; }
    }
}