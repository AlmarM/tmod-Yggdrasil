using Terraria.ID;
using Yggdrasil.Utils;

namespace Yggdrasil.Configs;

public static class RuneConfig
{
    /* Colors */
    public const string RuneTooltipColor = "AE804F";

    /* Text */
    public const string RunicDamageLabel = "runic";
    public const string RunePowerLabel = "Rune Power";
    public const string RunePowerRequiredLabel = $"{RunePowerLabel} {{0}}+";
    public const string RunemasterLabel = "Runemaster";
    public const string RunemasterTitleLabel = $"- {RunemasterLabel} Class -";

    public static readonly string ColoredRunicDamageLabel =
        TextUtils.GetColoredText(RuneTooltipColor, RunicDamageLabel);

    public static readonly string ColoredRunePowerLabel = TextUtils.GetColoredText(RuneTooltipColor, RunePowerLabel);
    public static readonly string RunePowerBonusLabel = $"Grant +{{0}} {ColoredRunePowerLabel}";
    public static readonly string ColoredRunemasterLabel = TextUtils.GetColoredText(RuneTooltipColor, RunemasterLabel);

    public static readonly string ColoredRunemasterTitleLabel =
        TextUtils.GetColoredText(RuneTooltipColor, RunemasterTitleLabel);


    /* Items Stats */
    public const int MaxRuneStack = 1;

    /* Prefixes */
    public static readonly int[] AllowedRunicVanillaPrefixes =
    {
        // Universal
        PrefixID.Broken,
        PrefixID.Damaged,
        PrefixID.Demonic,
        PrefixID.Forceful,
        PrefixID.Godly,
        PrefixID.Hurtful,
        PrefixID.Keen,
        PrefixID.Ruthless,
        PrefixID.Shoddy,
        PrefixID.Strong,
        PrefixID.Superior,
        PrefixID.Unpleasant,
        PrefixID.Weak,
        PrefixID.Zealous,

        // Common
        PrefixID.Agile,
        PrefixID.Annoying,
        PrefixID.Deadly2,
        PrefixID.Lazy,
        PrefixID.Murderous,
        PrefixID.Nasty,
        PrefixID.Nimble,
        PrefixID.Quick,
        PrefixID.Slow,
        PrefixID.Sluggish,

        // Melee
        PrefixID.Bulky,
        PrefixID.Dangerous,
        PrefixID.Dull,
        PrefixID.Heavy,
        PrefixID.Large,
        PrefixID.Legendary,
        PrefixID.Light,
        PrefixID.Massive,
        PrefixID.Pointy,
        PrefixID.Savage,
        PrefixID.Shameful,
        PrefixID.Sharp,
        PrefixID.Small,
        PrefixID.Terrible,
        PrefixID.Tiny,
        PrefixID.Unhappy
    };
}