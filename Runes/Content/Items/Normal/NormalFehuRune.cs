using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalFehuRune : FehuRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override int CritChanceBonus => 2;

    protected override int Rarity => ItemRarityID.Pink;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorFehuRune>()
        .AddIngredient(ItemID.HallowedPlateMail)
        .AddIngredient(ItemID.MoonCharm)
        .AddTile<DvergrForgeTile>()
        .Register();
}