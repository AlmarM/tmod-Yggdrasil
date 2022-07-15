using Terraria;

namespace Yggdrasil.Runes.Items.Algiz;

public abstract class AlgizRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Algiz;

    protected abstract int DefenseBonus { get; }

    public override void UpdateInventory(Player player)
    {
        player.statDefense += DefenseBonus;
    }
}