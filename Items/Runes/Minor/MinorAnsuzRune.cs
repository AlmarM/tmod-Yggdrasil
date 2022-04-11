using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Minor;

public class MinorAnsuzRune : AnsuzRune
{
    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => "A minor rune granting defense.";

    protected override int ManaAmount => 10;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Green;
    }
}