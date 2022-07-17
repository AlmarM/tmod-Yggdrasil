using Terraria;

namespace Yggdrasil.Runes.Content.Items;

public abstract class AlgizRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Algiz;

    protected abstract int DefenseBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.statDefense += DefenseBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, DefenseBonus));
    }
}