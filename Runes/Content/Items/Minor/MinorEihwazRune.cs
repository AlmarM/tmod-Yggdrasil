using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorEihwazRune : EihwazRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float MeleeDamageBonus => 0.05f;

    protected override int Rarity => ItemRarityID.Orange;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.WoodYoyo)
        .AddIngredient(ItemID.JungleYoyo)
        .AddTile<DvergrForgeTile>()
        .Register();
}