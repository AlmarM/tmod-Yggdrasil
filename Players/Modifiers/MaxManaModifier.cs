using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Players.Modifiers;

internal class MaxManaModifier : PlayerModifier
{
    public override string Description => MakeDescription(PlayerModifierConfig.MaxManaDescription, _maxManaAmount);

    private int _maxManaAmount;

    public MaxManaModifier(int maxManaAmount)
    {
        _maxManaAmount = maxManaAmount;
    }

    public override void Apply(Player player)
    {
        player.statManaMax2 += _maxManaAmount;
    }
}