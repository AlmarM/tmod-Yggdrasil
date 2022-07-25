using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalIngwazRune : IngwazRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override int HealthBonus => 25;

    protected override int Rarity => ItemRarityID.Pink;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorIngwazRune>()
        .AddIngredient(ItemID.LifeFruit)
        .AddIngredient(ItemID.LifeforcePotion, 5)
        .AddTile<DvergrForgeTile>()
        .Register();
}