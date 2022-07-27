using Terraria;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class OthalaRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Othala;

    protected abstract float NoAmmoConsumptionChance { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.GetYggdrasilPlayer().Stats.NoAmmoConsumptionChance.Value += NoAmmoConsumptionChance;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var percentage = TextUtils.GetPercentage(NoAmmoConsumptionChance);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, percentage));
    }
}