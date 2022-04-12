using Terraria;
using Yggdrasil.Configs;

namespace Yggdrasil.Players.Modifiers.Effects;

public class MaxManaModifier : IPlayerModifier
{
    public string Description => string.Format(PlayerModifierConfig.MaxManaDescription, _maxManaAmount);

    private int _maxManaAmount;

    public MaxManaModifier(int maxManaAmount)
    {
        _maxManaAmount = maxManaAmount;
    }

    public void Apply(Player player)
    {
        player.statManaMax2 += _maxManaAmount;
    }
}