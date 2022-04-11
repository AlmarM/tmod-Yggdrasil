using Terraria;

namespace Yggdrasil.Players.Modifiers;

public class MaxManaModifier : IPlayerModifier
{
    public PlayerModifierType Type => PlayerModifierType.MaxMana;

    public void Update(Player player, int amount)
    {
        player.statManaMax2 += amount;
    }
}