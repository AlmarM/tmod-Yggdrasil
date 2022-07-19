using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalDagazRune : DagazRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override float RangeDamageBoost => 0.1f;

    protected override int Rarity => ItemRarityID.LightRed;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorDagazRune>()
        .AddIngredient(ItemID.RangerEmblem)
        .AddIngredient(ItemID.MagicQuiver)
        .AddTile<DvergrForgeTile>()
        .Register();
}