using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Players.Modifiers;

public class ArmorPenetrationModifier : PlayerModifier
{
    public override string Description => MakeDescription(PlayerModifierConfig.ArmorPenetrationDescription, _armorPenetration);

    private int _armorPenetration;

    public ArmorPenetrationModifier(int armorPenetration)
    {
        _armorPenetration = armorPenetration;
    }

    public override void Apply(Player player)
    {
        player.armorPenetration += _armorPenetration;
    }
}