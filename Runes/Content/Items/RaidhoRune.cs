using Terraria;
using Yggdrasil.Runemaster;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class RaidhoRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Raidho;

    protected abstract float RunicAttackSpeedBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.GetAttackSpeed<RunicDamageClass>() += RunicAttackSpeedBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var percentage = TextUtils.GetPercentage(RunicAttackSpeedBonus);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, percentage));
    }
}