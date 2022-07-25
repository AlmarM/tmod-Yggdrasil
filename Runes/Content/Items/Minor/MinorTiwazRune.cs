using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorTiwazRune : TiwazRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float RunicDamageBonus => 0.05f;

    protected override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.Javelin, 100)
        .AddIngredient(ItemID.Lens, 5)
        .AddTile<DvergrForgeTile>()
        .Register();
}