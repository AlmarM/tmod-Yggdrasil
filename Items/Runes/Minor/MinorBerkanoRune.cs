using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Minor;

internal class MinorBerkanoRune : BerkanoRune
{
    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => "A rune granting regeneration.";

    protected override int lifeRegenAmount => 5;
    protected override int manaRegenAmount => 20;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Blue;
    }
}