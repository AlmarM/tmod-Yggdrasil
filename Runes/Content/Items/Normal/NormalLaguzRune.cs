using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalLaguzRune : LaguzRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override int HealthRestored => 3;

    protected override float HealInterval => 10f;

    protected override int Rarity => ItemRarityID.Lime;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorLaguzRune>()
        .AddIngredient(ItemID.GreaterHealingPotion, 10)
        .AddIngredient(ItemID.LifeFruit, 2)
        .AddIngredient(ItemID.SoulofMight, 15)
        .AddTile<DvergrForgeTile>()
        .Register();
}