using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorLaguzRune : LaguzRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override int HealthRestored => 1;

    protected override float HealInterval => 10f;

    protected override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.HealingPotion, 20)
        .AddIngredient(ItemID.CrispyHoneyBlock, 20)
        .AddTile<DvergrForgeTile>()
        .Register();
}