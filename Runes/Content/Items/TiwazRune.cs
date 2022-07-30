using Terraria;
using Yggdrasil.Runemaster;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class TiwazRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Tiwaz;

    protected abstract float RunicDamageBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.GetDamage<RunicDamageClass>() += RunicDamageBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var percentage = TextUtils.GetPercentage(RunicDamageBonus);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, percentage));
    }
}