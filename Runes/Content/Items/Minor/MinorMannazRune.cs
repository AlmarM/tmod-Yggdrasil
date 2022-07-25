using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorMannazRune : MannazRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float DamageBonus => 0.1f;
    protected override float Distance => 500f;

    protected override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.MeteoriteBar, 10)
        .AddIngredient(ItemID.SlimeGun)
        .AddTile<DvergrForgeTile>()
        .Register();
}