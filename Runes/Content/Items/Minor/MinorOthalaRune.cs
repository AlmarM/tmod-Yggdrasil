using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorOthalaRune : OthalaRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float NoAmmoConsumptionChance => 0.1f;

    protected override int Rarity => ItemRarityID.Green;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.Sandgun)
        .AddIngredient(ItemID.JestersArrow, 20)
        .AddTile<DvergrForgeTile>()
        .Register();
}