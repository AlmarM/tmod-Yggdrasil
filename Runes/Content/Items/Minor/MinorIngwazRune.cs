using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorIngwazRune : IngwazRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override int HealthBonus => 10;

    protected override int Rarity => ItemRarityID.Green;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.LifeCrystal)
        .AddIngredient(ItemID.HealingPotion, 5)
        .AddTile<DvergrForgeTile>()
        .Register();

}