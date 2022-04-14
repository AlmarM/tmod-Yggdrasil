using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Minor;

internal class MinorLaguzRune : LaguzRune
{
    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => "A minor rune granting renewal.";

    protected override int health => 1;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Blue;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.StoneBlock, 10) // temporary
        .AddIngredient(ItemID.HealingPotion, 20)
        .AddIngredient(ItemID.CrispyHoneyBlock, 20)
        .Register();
}