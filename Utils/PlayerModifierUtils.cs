using System;
using Yggdrasil.Configs;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Utils;

public static class PlayerModifierUtils
{
    public static string GetDescription(PlayerModifierType modifierType, int amount)
    {
        return modifierType switch
        {
            PlayerModifierType.Defense => FormatDescription(PlayerModifierConfig.DefenseDescription, amount),
            PlayerModifierType.MaxMana => FormatDescription(PlayerModifierConfig.MaxManaDescription, amount),
            _ => throw new ArgumentOutOfRangeException(nameof(modifierType))
        };
    }

    public static string FormatDescription(string description, params object[] args)
    {
        return string.Format(description, args);
    }
}