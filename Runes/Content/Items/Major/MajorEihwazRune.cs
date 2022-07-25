using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorEihwazRune : EihwazRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override float MeleeDamageBonus => 0.2f;

    protected override int Rarity => ItemRarityID.LightRed;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalEihwazRune>()
        .AddIngredient(ItemID.GolemFist)
        .AddIngredient(ItemID.FlowerPow)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}