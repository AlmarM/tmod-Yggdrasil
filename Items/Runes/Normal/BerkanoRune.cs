using Terraria.ID;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class BerkanoRune : Rune
{
    public override string RuneName => "Berkano";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting regeneration.";

    protected virtual int LifeRegenAmount => 10;
    protected virtual int ManaRegenAmount => 40;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Orange;
    }

    protected override void SetModifiers()
    {
        AddModifier(PlayerModifierType.LifeRegen, LifeRegenAmount);
		AddModifier(PlayerModifierType.ManaRegen, ManaRegenAmount);
    }
}