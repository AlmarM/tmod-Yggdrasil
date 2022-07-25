using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorMannazRune : MannazRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override float DamageBonus => 0.2f;
    protected override float Distance => 500f;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalMannazRune>()
        .AddIngredient(ItemID.BubbleGun)
        .AddIngredient(ItemID.SolarTablet)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}