using System.Text.RegularExpressions;
using Yggdrasil.Extensions;
using Yggdrasil.Runes;

namespace Yggdrasil.Utils;

public static class RuneUtils
{
    public static string FormatRuneTier(string format, RuneTier tier, bool forceLowerCase = false, bool clean = true)
    {
        string tierName = tier.GetDisplayName();

        if (forceLowerCase)
        {
            tierName = tierName.ToLowerInvariant();
        }

        var result = string.Format(format, tierName);

        return clean
            ? Regex.Replace(result.Trim(), @"\s+", " ")
            : result;
    }
}