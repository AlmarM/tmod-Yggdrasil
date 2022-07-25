using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalMannazRune : MannazRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override float DamageBonus => 0.15f;
    protected override float Distance => 500f;

    protected override int Rarity => ItemRarityID.Pink;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorMannazRune>()
        .AddIngredient(ItemID.CrystalVileShard)
        .AddIngredient(ItemID.SoulofMight, 20)
        .AddTile<DvergrForgeTile>()
        .Register();
}