using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorUruzRune : UruzRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float MeleeSpeedBonus => 0.03f;

    protected override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.AntlionMandible, 10)
        .AddIngredient(ItemID.Blinkroot, 10)
        .AddTile<DvergrForgeTile>()
        .Register();
}