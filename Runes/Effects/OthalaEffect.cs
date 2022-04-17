using Terraria;
using Yggdrasil.Configs;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Runes.Effects;

public class OthalaEffect : RuneEffect<OthalaEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters consumptionParameters = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.OthalaEffectDescription,
            consumptionParameters.ReduceAmmoConsumptionBonus);
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