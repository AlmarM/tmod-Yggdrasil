using Terraria;

namespace Yggdrasil.Players.Modifiers;

public class ManaRegenModifier : IPlayerModifier
{
    public PlayerModifierType Type => PlayerModifierType.ManaRegen;

    public void Update(Player player, int amount)
    {
        player.manaRegenBonus += amount;
    }
}