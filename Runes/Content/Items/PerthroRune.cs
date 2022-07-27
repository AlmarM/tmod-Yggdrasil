using Terraria;
using Yggdrasil.Extensions;
using Yggdrasil.PlayerStats;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class PerthroRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Perthro;

    protected abstract float ApplyBuffChance { get; }

    protected abstract float BuffDuration { get; }

    protected override void OnUpdateInventory(Player player)
    {
        ApplyRandomBuffStat randomBuffStat = player.GetYggdrasilPlayer().Stats.ApplyRandomBuff;
        randomBuffStat.Value.Chance += ApplyBuffChance;
        randomBuffStat.Value.Duration += BuffDuration;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var percentage = TextUtils.GetPercentage(ApplyBuffChance);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, percentage, BuffDuration));
    }
}