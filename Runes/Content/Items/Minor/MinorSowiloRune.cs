using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorSowiloRune : SowiloRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override int ArmorPenetrationBonus => 1;

    protected override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.SharkToothNecklace)
        .AddIngredient(ItemID.Cactus, 15)
        .AddTile<DvergrForgeTile>()
        .Register();
}