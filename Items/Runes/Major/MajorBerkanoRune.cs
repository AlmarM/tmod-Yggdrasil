using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Major;

public class MajorBerkanoRune : BerkanoRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A rune granting regeneration.";

    protected override int LifeRegenAmount => 20;
    protected override int ManaRegenAmount => 80;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
}