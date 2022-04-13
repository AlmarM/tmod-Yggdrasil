using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Players.Modifiers;

public class ManaRegenModifier : PlayerModifier
{
    public override string Description => MakeDescription(PlayerModifierConfig.ManaRegenDescription, _regenAmount);

    private int _regenAmount;

    public ManaRegenModifier(int regenAmount)
    {
        _regenAmount = regenAmount;
    }

    public override void Apply(Player player)
    {
        player.manaRegenBonus += _regenAmount;
    }
}