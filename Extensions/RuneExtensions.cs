using System;
using Yggdrasil.Runes;

namespace Yggdrasil.Extensions;

public static class RuneExtensions
{
    public static string GetItemPrefix(this RuneTier tier)
    {
        switch (tier)
        {
            case RuneTier.Minor:
            case RuneTier.Major:
                return Enum.GetName(tier);

            case RuneTier.Normal:
                return "";

            default:
                throw new ArgumentOutOfRangeException(nameof(tier), tier, null);
        }
    }
}