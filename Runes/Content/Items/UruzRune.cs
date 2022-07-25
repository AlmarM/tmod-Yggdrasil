using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class UruzRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Uruz;

    protected abstract float MeleeSpeedBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.GetAttackSpeed(DamageClass.Melee) += MeleeSpeedBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var percentage = TextUtils.GetPercentage(MeleeSpeedBonus);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, percentage));
    }
}