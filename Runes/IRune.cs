namespace Yggdrasil.Runes;

internal interface IRune
{
    string Label { get; }

    RuneTier Tier { get; }

    string TooltipDescription { get; }

    int Rarity { get; }

    int RunePower { get; }
}