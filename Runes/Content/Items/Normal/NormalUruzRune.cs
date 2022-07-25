using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalUruzRune : UruzRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override float MeleeSpeedBonus => 0.05f;

    protected override int Rarity => ItemRarityID.LightRed;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorUruzRune>()
        .AddIngredient(ItemID.TitanGlove)
        .AddIngredient(ItemID.SoulofFlight, 20)
        .AddTile<DvergrForgeTile>()
        .Register();
}