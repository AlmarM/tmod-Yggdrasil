using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalJeraRune : JeraRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override int AggroReduceBonus => 50;

    protected override int Rarity => ItemRarityID.Pink;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorJeraRune>()
        .AddIngredient(ItemID.SoulofFright, 10)
        .AddIngredient(ItemID.SoulofNight, 10)
        .AddTile<DvergrForgeTile>()
        .Register();
}