using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

internal class MajorAlgizRune : AlgizRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting defense.";

    protected override int defenseAmount => 3;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<AlgizRune>(3)
        .AddIngredient(ItemID.PaladinsShield)
        .AddIngredient(ItemID.BeetleHusk, 10)
        .Register();
}