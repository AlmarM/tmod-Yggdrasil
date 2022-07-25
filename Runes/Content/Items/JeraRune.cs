using Terraria;

namespace Yggdrasil.Runes.Content.Items;

public abstract class JeraRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Jera;

    protected abstract int AggroReduceBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.aggro -= AggroReduceBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, AggroReduceBonus));
    }
}