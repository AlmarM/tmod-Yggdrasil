using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

internal class MajorBerkanoRune : BerkanoRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A rune granting regeneration.";

    protected override int lifeRegenAmount => 20;
    protected override int manaRegenAmount => 80;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
}