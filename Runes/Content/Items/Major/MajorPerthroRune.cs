using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorPerthroRune : PerthroRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override float ApplyBuffChance => 0.07f;

    protected override float BuffDuration => 5f;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalPerthroRune>()
        .AddIngredient(ItemID.InfernoFork)
        .AddIngredient(ItemID.Nanites, 50)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}