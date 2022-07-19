using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorDagazRune : DagazRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float RangeDamageBoost => 0.05f;

    protected override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.FossilOre, 25)
        .AddIngredient(ItemID.FlareGun)
        .AddTile<DvergrForgeTile>()
        .Register();
}