using Terraria;
using Yggdrasil.Extensions;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class KenazRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Kenaz;

    protected abstract float DodgeChanceBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.GetYggdrasilPlayer().Stats.DodgeChance.Value += DodgeChanceBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var percentage = TextUtils.GetPercentage(DodgeChanceBonus);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, percentage));
    }
}