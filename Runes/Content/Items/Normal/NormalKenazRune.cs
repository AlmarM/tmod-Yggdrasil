using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalKenazRune : KenazRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override float DodgeChanceBonus => 0.02f;

    protected override int Rarity => ItemRarityID.Pink;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorKenazRune>()
        .AddIngredient(ItemID.SmokeBomb, 10)
        .AddIngredient(ItemID.SoulofSight, 10)
        .AddIngredient(ItemID.DarkShard, 2)
        .AddTile<DvergrForgeTile>()
        .Register();
}