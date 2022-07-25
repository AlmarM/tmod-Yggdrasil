using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalSowiloRune : SowiloRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override int ArmorPenetrationBonus => 3;

    protected override int Rarity => ItemRarityID.Pink;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorSowiloRune>()
        .AddIngredient(ItemID.UnicornHorn, 10)
        .AddIngredient(ItemID.Drax)
        .AddTile<DvergrForgeTile>()
        .Register();
}