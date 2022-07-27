using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalNauthizRune : NauthizRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override float InvincibilityBonus => 0.25f;

    protected override int Rarity => ItemRarityID.Pink;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorNauthizRune>()
        .AddIngredient(ItemID.CrossNecklace)
        .AddIngredient(ItemID.SoulofMight, 5)
        .AddIngredient(ItemID.SoulofFright, 5)
        .AddTile<DvergrForgeTile>()
        .Register();
}