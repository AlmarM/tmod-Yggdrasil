using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Major;

public class MajorAnsuzRune : AnsuzRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting wisdom.";

    protected override int ManaAmount => 30;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
}