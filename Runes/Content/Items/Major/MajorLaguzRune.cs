using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorLaguzRune : LaguzRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override int HealthRestored => 5;

    protected override float HealInterval => 10f;

    protected override int Rarity => ItemRarityID.Cyan;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalLaguzRune>()
        .AddIngredient(ItemID.SpectreHood)
        .AddIngredient(ItemID.SuperHealingPotion, 10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}