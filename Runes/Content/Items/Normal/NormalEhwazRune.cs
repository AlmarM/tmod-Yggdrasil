using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalEhwazRune : EhwazRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override float MovementSpeedBonus => 0.1f;

    protected override int Rarity => ItemRarityID.Orange;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorEhwazRune>()
        .AddIngredient(ItemID.AsphaltBlock, 50)
        .AddIngredient(ItemID.SoulofFlight, 20)
        .AddTile<DvergrForgeTile>()
        .Register();
}