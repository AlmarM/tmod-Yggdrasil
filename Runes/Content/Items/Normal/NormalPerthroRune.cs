using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalPerthroRune : PerthroRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override float ApplyBuffChance => 0.05f;

    protected override float BuffDuration => 5f;

    protected override int Rarity => ItemRarityID.Pink;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorPerthroRune>()
        .AddIngredient(ItemID.FlowerofFrost)
        .AddIngredient(ItemID.FlaskofVenom, 10)
        .AddTile<DvergrForgeTile>()
        .Register();
}