using Terraria.ID;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class AlgizRune : Rune
{
    public override string RuneName => "Algiz";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting defense.";

    protected virtual int DefenseAmount => 2;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Lime;
    }

    protected override void SetModifiers()
    {
        AddModifier(PlayerModifierType.Defense, DefenseAmount);
    }
}