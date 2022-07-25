using Terraria;
using Terraria.ModLoader;
using Yggdrasil.Utils;

namespace Yggdrasil.Runes.Content.Items;

public abstract class GeboRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Gebo;

    protected abstract float MinionDamageBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.GetDamage(DamageClass.Summon) += MinionDamageBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        var percentage = TextUtils.GetPercentage(MinionDamageBonus);
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, percentage));
    }
}