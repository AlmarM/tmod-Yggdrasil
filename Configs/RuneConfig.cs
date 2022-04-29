using Yggdrasil.Utils;

namespace Yggdrasil.Configs;

public static class RuneConfig
{
    /* Colors */
    public const string RuneTooltipColor = "AE804F";

    /* Text */
    public const string RunicDamageLabel = "runic";
    public static string RunicDamageTooltip = TextUtils.GetColoredText(RuneTooltipColor, RunicDamageLabel);
    public const string RunePowerLabel = "Rune Power {0}+";

    /* Items Stats */
    public const int MaxRuneStack = 1;
}