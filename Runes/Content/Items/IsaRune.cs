using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class IsaRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Isa;

    protected abstract float DamageBonus { get; }
    protected abstract float HealthThreshold { get; }

    protected override void OnUpdateInventory(Player player)
    {
        if (player.statLife < HealthThreshold * player.statLifeMax2)
        {
            player.GetDamage(DamageClass.Generic) += DamageBonus;
        }
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var damagePercentage = TextUtils.GetPercentage(DamageBonus);
        var healthPercentage = TextUtils.GetPercentage(HealthThreshold);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, damagePercentage, healthPercentage));
    }
}