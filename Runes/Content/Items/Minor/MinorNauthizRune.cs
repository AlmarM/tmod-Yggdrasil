using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorNauthizRune : NauthizRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float InvincibilityBonus => 0.1f;

    protected override int Rarity => ItemRarityID.Green;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.HoneyComb)
        .AddIngredient(ItemID.GuideVoodooDoll)
        .AddTile<DvergrForgeTile>()
        .Register();
}