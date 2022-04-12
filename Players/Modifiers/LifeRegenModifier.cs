using Terraria;

namespace Yggdrasil.Players.Modifiers;

public class LifeRegenModifier : IPlayerModifier
{
    public PlayerModifierType Type => PlayerModifierType.LifeRegen;

    public void Update(Player player, int amount)
    {
        player.lifeRegen += amount;
    }
}