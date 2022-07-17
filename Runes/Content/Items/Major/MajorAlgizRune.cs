using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorAlgizRune : AlgizRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override int DefenseBonus => 3;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalAlgizRune>()
        .AddIngredient(ItemID.PaladinsShield)
        .AddIngredient(ItemID.BeetleHusk, 10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}