using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
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

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorAlgizRune>(3)
        .AddIngredient(ItemID.HallowedBar, 10)
        .AddIngredient(ItemID.TurtleShell)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new DefenseModifier(DefenseAmount));
    }
}