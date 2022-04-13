using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

internal class MajorIsaRune : IsaRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune giving a challenge.";

    protected override float damageBonus => 1f;
    protected override float healthThreshold => 0.15f;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Cyan;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<IsaRune>(3)
        .AddIngredient(ItemID.LihzahrdBanner)
        .AddIngredient(ItemID.SolarSolenianBanner)
        .Register();
}