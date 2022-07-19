using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalWunjoRune : WunjoRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override float DamageReductionBonus => 0.05f;

    protected override int Rarity => ItemRarityID.LightRed;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorWunjoRune>()
        .AddIngredient(ItemID.FrozenTurtleShell)
        .AddIngredient(ItemID.SkeletronPrimeTrophy)
        .AddIngredient(ItemID.HallowedBar, 30)
        .AddTile<DvergrForgeTile>()
        .Register();
}