using Terraria;

namespace Yggdrasil.Players.Modifiers;

public interface IPlayerModifier
{
    string Description { get; }

    void Apply(Player player);
}