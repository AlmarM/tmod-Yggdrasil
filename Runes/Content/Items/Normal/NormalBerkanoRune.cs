using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalBerkanoRune : BerkanoRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override int LifeRegenBonus => 5;

    protected override int ManaRegenBonus => 5;

    protected override int Rarity => ItemRarityID.Lime;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorBerkanoRune>()
        .AddIngredient(ItemID.MoonStone)
        .AddIngredient(ItemID.LifeFruit, 2)
        .AddTile<DvergrForgeTile>()
        .Register();
}