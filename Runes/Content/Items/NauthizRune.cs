using Terraria;
using Yggdrasil.Extensions;

namespace Yggdrasil.Runes.Content.Items;

public abstract class NauthizRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Nauthiz;

    protected abstract float InvincibilityBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.GetYggdrasilPlayer().Stats.InvincibilityTime.Value += InvincibilityBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, InvincibilityBonus));
    }
}