using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalAlgizRune : AlgizRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override int DefenseBonus => 5;

    protected override int Rarity => ItemRarityID.Lime;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorAlgizRune>()
        .AddIngredient(ItemID.HallowedBar, 10)
        .AddIngredient(ItemID.TurtleShell)
        .AddTile<DvergrForgeTile>()
        .Register();
}