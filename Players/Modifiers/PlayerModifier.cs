using Terraria;

namespace Yggdrasil.Players.Modifiers;

public abstract class PlayerModifier : IPlayerModifier
{
    public abstract string Description { get; }

    public abstract void Apply(Player player);

    protected static string MakeDescription(string descriptionTemplate, params object[] stats)
    {
        return string.Format(descriptionTemplate, stats);
    }
}