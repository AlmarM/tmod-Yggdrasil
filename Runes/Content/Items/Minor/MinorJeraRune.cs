using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorJeraRune : JeraRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override int AggroReduceBonus => 20;

    protected override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.InvisibilityPotion, 5)
        .AddIngredient(ItemID.Shiverthorn, 5)
        .AddTile<DvergrForgeTile>()
        .Register();

}