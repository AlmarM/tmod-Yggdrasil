using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorEhwazRune : EhwazRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float MovementSpeedBonus => 0.05f;

    protected override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.IceBlock, 30)
        .AddIngredient(ItemID.SwiftnessPotion, 5)
        .AddTile<DvergrForgeTile>()
        .Register();
}