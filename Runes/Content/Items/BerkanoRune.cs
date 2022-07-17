using Terraria;

namespace Yggdrasil.Runes.Content.Items;

public abstract class BerkanoRune : Rune
{
    protected override RuneTooltipText TooltipText => RuneTooltipText.Berkano;

    protected abstract int LifeRegenBonus { get; }

    protected abstract int ManaRegenBonus { get; }

    protected override void OnUpdateInventory(Player player)
    {
        player.lifeRegen += LifeRegenBonus;
        player.manaRegen += ManaRegenBonus;
    }

    protected override void ModifyEffectTooltipBlock(TooltipBlock block)
    {
        block.AddLine(string.Format(TooltipText.EffectDescriptionFormat, LifeRegenBonus, ManaRegenBonus));
    }
}