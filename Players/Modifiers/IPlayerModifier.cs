using Terraria;

namespace Yggdrasil.Players.Modifiers;

public interface IPlayerModifier
{
    PlayerModifierType Type { get; }

    void Update(Player player, int amount);
}