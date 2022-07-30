using Terraria;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class ThurisazRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Thurisaz;

    protected abstract float ThornsBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.thorns += ThornsBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var percentage = TextUtils.GetPercentage(ThornsBonus);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, percentage));
    }
}