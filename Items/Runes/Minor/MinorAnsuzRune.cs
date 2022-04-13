using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Minor;

internal class MinorAnsuzRune : AnsuzRune
{
    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => "A minor rune granting defense.";

    protected override int manaAmount => 10;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Green;
    }
}