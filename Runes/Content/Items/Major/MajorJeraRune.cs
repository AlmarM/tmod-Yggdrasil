using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorJeraRune : JeraRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override int AggroReduceBonus => 100;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalJeraRune>()
        .AddIngredient(ItemID.PsychoKnife)
        .AddIngredient(ItemID.ShroomiteBar, 10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}