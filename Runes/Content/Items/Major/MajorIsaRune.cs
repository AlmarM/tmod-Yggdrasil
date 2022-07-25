using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorIsaRune : IsaRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override float DamageBonus => 1f;

    protected override float HealthThreshold => 0.15f;

    protected override int Rarity => ItemRarityID.Cyan;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalIsaRune>()
        .AddIngredient(ItemID.LihzahrdBanner)
        .AddIngredient(ItemID.SolarSolenianBanner)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}