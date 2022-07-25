using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorFehuRune : FehuRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override int CritChanceBonus => 1;

    protected override int Rarity => ItemRarityID.Orange;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.JungleShirt)
        .AddIngredient(ItemID.Ale, 10)
        .AddTile<DvergrForgeTile>()
        .Register();
}