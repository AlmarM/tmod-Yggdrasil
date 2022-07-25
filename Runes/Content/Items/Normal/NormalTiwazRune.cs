using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalTiwazRune : TiwazRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override float RunicDamageBonus => 0.1f;

    protected override int Rarity => ItemRarityID.Pink;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorTiwazRune>()
        .AddIngredient(ItemID.ShadowFlameHexDoll)
        .AddIngredient(ItemID.SoulofFright, 10)
        .AddTile<DvergrForgeTile>()
        .Register();
}