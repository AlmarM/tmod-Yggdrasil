using Terraria;

namespace Yggdrasil.Players.Modifiers;

public class DefenseModifier : IPlayerModifier
{
    public PlayerModifierType Type => PlayerModifierType.Defense;

    public void Update(Player player, int amount)
    {
        player.statDefense += amount;
    }
}