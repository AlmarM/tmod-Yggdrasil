using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalAnsuzRune : AnsuzRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override int MaxManaBonus => 20;

    protected override int Rarity => ItemRarityID.Orange;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorAnsuzRune>()
        .AddIngredient(ItemID.NaturesGift)
        .AddIngredient(ItemID.CrystalBall)
        .AddTile<DvergrForgeTile>()
        .Register();
}