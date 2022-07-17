using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorAnsuzRune : AnsuzRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override int MaxManaBonus => 10;

    protected override int Rarity => ItemRarityID.Green;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.ManaCrystal, 5)
        .AddIngredient(ItemID.BandofStarpower)
        .AddTile<DvergrForgeTile>()
        .Register();
}