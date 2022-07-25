using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class EihwazRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Eihwaz;

    protected abstract float MeleeDamageBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.GetDamage(DamageClass.Melee) += MeleeDamageBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var percentage = TextUtils.GetPercentage(MeleeDamageBonus);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, percentage));
    }
}