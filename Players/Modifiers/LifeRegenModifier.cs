using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Players.Modifiers;

internal class LifeRegenModifier : PlayerModifier
{
    public override string Description => MakeDescription(PlayerModifierConfig.LifeRegenDescription, _regenAmount);

    private int _regenAmount;

    public LifeRegenModifier(int regenAmount)
    {
        _regenAmount = regenAmount;
    }

    public override void Apply(Player player)
    {
        player.lifeRegen += _regenAmount;
    }
}