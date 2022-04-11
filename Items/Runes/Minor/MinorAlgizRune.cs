using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Minor;

public class MinorAlgizRune : AlgizRune
{
    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => "A minor rune granting defense.";

    protected override int DefenseAmount => 1;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Blue;
    }
}