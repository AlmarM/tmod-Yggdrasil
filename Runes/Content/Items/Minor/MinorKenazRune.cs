using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorKenazRune : KenazRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float DodgeChanceBonus => 0.01f;

    protected override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.NinjaHood)
        .AddIngredient(ItemID.InvisibilityPotion, 5)
        .AddTile<DvergrForgeTile>()
        .Register();
}