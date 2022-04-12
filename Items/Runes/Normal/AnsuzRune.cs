using Terraria.ID;
using Yggdrasil.Players.Modifiers.Effects;

namespace Yggdrasil.Items.Runes.Normal;

public class AnsuzRune : Rune
{
    public override string RuneName => "Ansuz";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting wisdom.";

    protected virtual int manaAmount => 20;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Orange;
    }

    protected override void SetModifiers()
    {
        AddModifier(new MaxManaModifier(manaAmount));
    }
}