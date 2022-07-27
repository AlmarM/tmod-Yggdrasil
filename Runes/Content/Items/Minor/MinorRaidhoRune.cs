using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorRaidhoRune : RaidhoRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float RunicAttackSpeedBonus => 0.05f;

    protected override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.FossilOre, 25)
        .AddIngredient(ItemID.Javelin, 100)
        .AddTile<DvergrForgeTile>()
        .Register();
}