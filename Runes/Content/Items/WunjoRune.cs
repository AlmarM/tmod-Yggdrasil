using Terraria;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class WunjoRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Wunjo;

    protected abstract float DamageReductionBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.endurance += DamageReductionBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var percentage = TextUtils.GetPercentage(DamageReductionBonus);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, percentage));
    }
}