using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class DagazRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Dagaz;

    protected abstract float RangeDamageBoost { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.GetDamage(DamageClass.Ranged) += RangeDamageBoost;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var percentage = TextUtils.GetPercentage(RangeDamageBoost);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, percentage));
    }
}