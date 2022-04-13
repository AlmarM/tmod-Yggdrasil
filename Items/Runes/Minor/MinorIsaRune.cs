using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Minor;

internal class MinorIsaRune : IsaRune
{
    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => "A minor rune giving a challenge.";

    protected override float damageBonus => 0.25f;
    protected override float healthThreshold => 0.12f;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Green;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.StoneBlock, 10) // temporary
        .AddIngredient(ItemID.SlimeBanner)
        .AddIngredient(ItemID.BatBanner)
        .Register();
}