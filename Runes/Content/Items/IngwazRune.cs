using Terraria;

namespace Yggdrasil.Runes.Content.Items;

public abstract class IngwazRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Ingwaz;

    protected abstract int HealthBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.statLifeMax2 += HealthBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, HealthBonus));
    }
}