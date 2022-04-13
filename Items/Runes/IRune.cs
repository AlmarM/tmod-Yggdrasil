namespace Yggdrasil.Items.Runes;

internal interface IRune
{
    string RuneName { get; }

    RuneTier Tier { get; }

    string TooltipDescription { get; }
}