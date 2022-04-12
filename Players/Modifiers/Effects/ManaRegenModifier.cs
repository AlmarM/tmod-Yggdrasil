using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Players.Modifiers.Effects;

public class ManaRegenModifier : IPlayerModifier
{
    public string Description => string.Format(PlayerModifierConfig.ManaRegenDescription, _regenAmount);

    private int _regenAmount;

    public ManaRegenModifier(int regenAmount)
    {
        _regenAmount = regenAmount;
    }

    public void Apply(Player player)
    {
        player.manaRegenBonus += _regenAmount;
    }
}