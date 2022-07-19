using Terraria.ID;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Minor;

public class MinorWunjoRune : WunjoRune
{
    protected override RuneTier Tier => RuneTier.Minor;

    protected override float DamageReductionBonus => 0.03f;

    protected override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.AncientNecroHelmet)
        .AddIngredient(ItemID.SkeletronTrophy)
        .AddIngredient(ItemID.HellstoneBar, 20)
        .AddTile<DvergrForgeTile>()
        .Register();
}