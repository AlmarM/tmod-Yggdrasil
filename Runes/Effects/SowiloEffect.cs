using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Configs;

namespace Yggdrasil.Runes.Effects;

public class SowiloEffect : RuneEffect<SowiloEffect.Parameters>
{
    public override string GetDescription(IRuneEffectParameters effectParameters)
    {
        Parameters penetrationParameters = CastParameters(effectParameters);
        return MakeDescription(RuneEffectConfig.SowiloEffectDescription, penetrationParameters.ArmorPenetrationBonus);
    }

    public override void Apply(Player player, IRuneEffectParameters effectParameters)
    {
        Parameters penetrationParameters = CastParameters(effectParameters);
        player.GetArmorPenetration(DamageClass.Generic) += penetrationParameters.ArmorPenetrationBonus;
    }

    public struct Parameters : IRuneEffectParameters
    {
        public Parameters(int armorPenetrationBonus)
        {
            ArmorPenetrationBonus = armorPenetrationBonus;
        }

        public int ArmorPenetrationBonus { get; }
    }
}