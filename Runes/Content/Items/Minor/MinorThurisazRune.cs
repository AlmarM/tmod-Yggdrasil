using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorThurisazRune : ThurisazRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float ThornsBonus => 0.1f;

    protected override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.Cactus, 10)
        .AddIngredient(ItemID.Stinger, 2)
        .AddTile<DvergrForgeTile>()
        .Register();
}