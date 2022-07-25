using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalHagalazRune : HagalazRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override float MagicDamageBonus => 0.1f;

    protected override int Rarity => ItemRarityID.Pink;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorHagalazRune>()
        .AddIngredient(ItemID.SorcererEmblem)
        .AddIngredient(ItemID.MagicalHarp)
        .AddTile<DvergrForgeTile>()
        .Register();
}