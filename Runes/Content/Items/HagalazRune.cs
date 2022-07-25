using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class HagalazRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Hagalaz;

    protected abstract float MagicDamageBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.GetDamage(DamageClass.Magic) += MagicDamageBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var percentage = TextUtils.GetPercentage(MagicDamageBonus);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, percentage));
    }
}