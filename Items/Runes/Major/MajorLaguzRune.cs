using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

internal class MajorLaguzRune : LaguzRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting renewal.";

    protected override int health => 5;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Cyan;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<LaguzRune>(3)
        .AddIngredient(ItemID.SpectreHood)
        .AddIngredient(ItemID.SuperHealingPotion, 10)
        .Register();
}