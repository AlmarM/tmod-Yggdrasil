using Terraria.ID;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class AnsuzRune : Rune
{
    public override string RuneName => "Ansuz";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting wisdom.";

    protected virtual int ManaAmount => 20;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Orange;
    }

    protected override void SetModifiers()
    {
        AddModifier(new MaxManaModifier(ManaAmount));
    }
}