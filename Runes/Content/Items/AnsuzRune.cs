using Terraria;

namespace Yggdrasil.Runes.Content.Items;

public abstract class AnsuzRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Ansuz;

    protected abstract int MaxManaBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.statManaMax2 += MaxManaBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, MaxManaBonus));
    }
}