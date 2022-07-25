using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorIsaRune : IsaRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float DamageBonus => 0.25f;

    protected override float HealthThreshold => 0.1f;

    protected override int Rarity => ItemRarityID.Green;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.SlimeBanner)
        .AddIngredient(ItemID.BatBanner)
        .AddTile<DvergrForgeTile>()
        .Register();
}