using Terraria;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class EhwazRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Ehwaz;

    protected abstract float MovementSpeedBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.moveSpeed += MovementSpeedBonus;
        player.maxRunSpeed *= 1f + MovementSpeedBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var percentage = TextUtils.GetPercentage(MovementSpeedBonus);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, percentage));
    }
}