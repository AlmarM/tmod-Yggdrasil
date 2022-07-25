using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorHagalazRune : HagalazRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float MagicDamageBonus => 0.05f;

    protected override int Rarity => ItemRarityID.Green;

    public override void AddRecipes() => CreateRecipe()
      .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.WizardHat)
        .AddIngredient(ItemID.MagicMissile)
        .AddTile<DvergrForgeTile>()
        .Register();
}