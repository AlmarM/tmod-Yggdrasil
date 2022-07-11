namespace Yggdrasil.Runes.Items.Algiz;

public abstract class AlgizRune : Rune
{
    protected override string ItemName => "Algiz";

    protected abstract override RuneTier Tier { get; }
}