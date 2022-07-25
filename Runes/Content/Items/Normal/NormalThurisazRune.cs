using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalThurisazRune : ThurisazRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override float ThornsBonus => 0.25f;

    protected override int Rarity => ItemRarityID.Lime;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorThurisazRune>()
        .AddIngredient(ItemID.TurtleShell)
        .AddIngredient(ItemID.Spike, 10)
        .AddTile<DvergrForgeTile>()
        .Register();
}