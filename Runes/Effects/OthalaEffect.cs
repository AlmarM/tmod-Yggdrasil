using Terraria;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Effects;

public class OthalaEffect : RuneEffect<OthalaEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters consumptionParameters = CastParameters(effectParameters);
        string percentage = TextUtils.GetPercentage(consumptionParameters.ReduceAmmoConsumptionBonus);
        
        return MakeDescription(RuneEffectConfig.OthalaEffectDescription, percentage);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters consumptionParameters = CastParameters(effectParameters);
        player.GetModPlayer<RunePlayer>().PreventAmmoConsumptionChance +=
            consumptionParameters.ReduceAmmoConsumptionBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(float reduceAmmoConsumptionBonus)
        {
            ReduceAmmoConsumptionBonus = reduceAmmoConsumptionBonus;
        }

        public float ReduceAmmoConsumptionBonus { get; }
    }
}