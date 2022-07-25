using Terraria;

namespace Yggdrasil.Runes.Content.Items;

public abstract class KenazRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Kenaz;

    protected abstract int DodgeChanceBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        //player.GetModPlayer<RunemasterPlayer>().DodgeChance += DodgeChanceBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, DodgeChanceBonus));
    }
}