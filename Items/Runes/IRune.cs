namespace Yggdrasil.Items.Runes;

public interface IRune
{
    string RuneName { get; }

    RuneTier Tier { get; }

    string TooltipDescription { get; }
}