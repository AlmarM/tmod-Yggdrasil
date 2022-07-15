using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Items.Algiz;

public class MinorAlgizRuneT : AlgizRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override int DefenseBonus => 1;

    protected override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.Shackle)
        .AddIngredient(ItemID.ObsidianSkull)
        .AddTile<DvergrForgeTile>()
        .Register();
}