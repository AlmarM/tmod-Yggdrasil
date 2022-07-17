using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorBerkanoRune : BerkanoRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override int LifeRegenBonus => 3;

    protected override int ManaRegenBonus => 3;

    protected override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.StarinaBottle, 3)
        .AddIngredient(ItemID.HeartLantern, 3)
        .AddTile<DvergrForgeTile>()
        .Register();
}