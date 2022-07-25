using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorGeboRune : GeboRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float MinionDamageBonus => 0.05f;

    protected override int Rarity => ItemRarityID.Orange;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.BeeWax, 30)
        .AddIngredient(ItemID.ImpStaff)
        .AddTile<DvergrForgeTile>()
        .Register();
}