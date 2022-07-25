using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalIsaRune : IsaRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override float DamageBonus => 0.5f;
    
    protected override float HealthThreshold => 0.12f;

    protected override int Rarity => ItemRarityID.Lime;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorIsaRune>()
        .AddIngredient(ItemID.IlluminantBatBanner)
        .AddIngredient(ItemID.PirateBanner)
        .AddTile<DvergrForgeTile>()
        .Register();
}