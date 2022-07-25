using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class FehuRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Fehu;

    protected abstract int CritChanceBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.GetCritChance(DamageClass.Generic) += CritChanceBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var percentage = TextUtils.GetPercentage(CritChanceBonus);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, percentage));
    }
}