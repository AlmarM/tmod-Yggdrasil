using Terraria.ID;
using Yggdrasil.Utils;

namespace Yggdrasil.Configs;

public static class RuneConfig
{
    /* Colors */
    public const string RuneTooltipColor = "AE804F";
    public const string FocusTooltipColor = "FC7B03";
    public const string InsanityTextColor = "CD2340";

    /* Text */
    public const string RunicDamageLabel = "runic";
    public const string RunePowerLabel = "Runic Power";
    public const string RunePowerRequiredLabel = $"{RunePowerLabel} {{0}}+";
    public const string RunemasterLabel = "Runemaster";
    public const string RunemasterTitleLabel = $"- {RunemasterLabel} Class -";
    public const string FocusLabel = "Focus";
    public const string FocusRequiredLabel = $"{FocusLabel} {{0}}+";
    public const string InsanityLabel = "insanity";

    public static readonly string ColoredRunicDamageLabel =
        TextUtils.GetColoredText(RuneTooltipColor, RunicDamageLabel);

    public static readonly string ColoredRunePowerLabel = TextUtils.GetColoredText(RuneTooltipColor, RunePowerLabel);
    public static readonly string RunePowerBonusLabel = $"Grants +{{0}} {ColoredRunePowerLabel}";
    public static readonly string ColoredRunemasterLabel = TextUtils.GetColoredText(RuneTooltipColor, RunemasterLabel);

    public static readonly string ColoredRunemasterTitleLabel =
        TextUtils.GetColoredText(RuneTooltipColor, RunemasterTitleLabel);

    public static readonly string ColoredFocusLabel = TextUtils.GetColoredText(FocusTooltipColor, FocusLabel);

    public static readonly string ColoredInsanityLabel = TextUtils.GetColoredText(InsanityTextColor, InsanityLabel);


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
        //PrefixID.Large, //This doesn't affect the runic tablets as it boosts size
        PrefixID.Legendary,
        PrefixID.Light,
        //PrefixID.Massive, //This doesn't affect the runic tablets as it boosts size
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