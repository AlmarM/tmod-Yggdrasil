using Terraria;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class LaguzRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Laguz;

    protected abstract int HealthRestored { get; }

    protected abstract float HealInterval { get; }

    protected int timeLeftToHeal;

    protected override void OnUpdateInventory(Player player)
    {
        if (player.statLife >= player.statLifeMax2 || --timeLeftToHeal > 0)
        {
            return;
        }

        timeLeftToHeal = TimeUtils.SecondsToTicks(HealInterval);

        player.statLife += HealthRestored;
        player.HealEffect(HealthRestored);
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, HealthRestored, HealInterval));
    }
}