using Terraria;
using Terraria.ModLoader;

namespace Yggdrasil.Runes.Content.Items;

public abstract class SowiloRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Sowilo;

    protected abstract int ArmorPenetrationBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.GetArmorPenetration(DamageClass.Generic) += ArmorPenetrationBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, ArmorPenetrationBonus));
    }
}