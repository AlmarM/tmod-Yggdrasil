using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorPerthroRune : PerthroRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float ApplyBuffChance => 0.03f;

    protected override float BuffDuration => 5f;

    protected override int Rarity => ItemRarityID.LightRed;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.LavaBucket)
        .AddIngredient(ItemID.FlaskofFire, 10)
        .AddIngredient(ItemID.FlaskofPoison, 10)
        .AddTile<DvergrForgeTile>()
        .Register();
}