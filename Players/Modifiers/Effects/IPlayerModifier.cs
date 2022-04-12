using Terraria;

namespace Yggdrasil.Players.Modifiers.Effects;

public interface IPlayerModifier
{
    string Description { get; }

    void Apply(Player player);
}