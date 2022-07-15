namespace Yggdrasil.Runes;

public class RuneTooltipText
{
    public string Name { get; set; }

    public string DescriptionFormat { get; set; }

    public string EffectDescriptionFormat { get; set; }

    public static RuneTooltipText Algiz = new()
    {
        Name = "Algiz",
        DescriptionFormat = "A {0}rune granting defense.",
        EffectDescriptionFormat = "Increases defense by {0}"
    };
}