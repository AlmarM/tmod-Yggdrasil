using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Players.Modifiers.Effects;

public class LifeRegenModifier : IPlayerModifier
{
    public string Description => string.Format(PlayerModifierConfig.LifeRegenDescription, _regenAmount);

    private int _regenAmount;

    public LifeRegenModifier(int regenAmount)
    {
        _regenAmount = regenAmount;
    }

    public void Apply(Player player)
    {
        player.lifeRegen += _regenAmount;
    }
}