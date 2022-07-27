using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Minor;

namespace Yggdrasil.Runes.Content.Items.Normal;

public class NormalOthalaRune : OthalaRune
{
    protected override RuneTier Tier => RuneTier.Normal;

    protected override float NoAmmoConsumptionChance => 0.15f;

    protected override int Rarity => ItemRarityID.LightPurple;

    protected override int Value => Item.sellPrice(silver: 10);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorOthalaRune>()
        .AddIngredient(ItemID.EndlessQuiver)
        .AddIngredient(ItemID.EndlessMusketPouch, 5)
        .AddIngredient(ItemID.DaedalusStormbow)
        .AddTile<DvergrForgeTile>()
        .Register();
}