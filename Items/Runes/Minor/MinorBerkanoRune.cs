using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Minor;

public class MinorBerkanoRune : BerkanoRune
{
    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => "A rune granting regeneration.";

    protected override int LifeRegenAmount => 5;
    protected override int ManaRegenAmount => 20;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Blue;
    }
}