using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorIngwazRune : IngwazRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override int HealthBonus => 50;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalIngwazRune>()
        .AddIngredient(ItemID.SunStone)
        .AddIngredient(ItemID.MoonStone)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}