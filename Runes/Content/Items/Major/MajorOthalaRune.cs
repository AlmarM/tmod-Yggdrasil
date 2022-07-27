using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorOthalaRune : OthalaRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override float NoAmmoConsumptionChance => 0.2f;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalOthalaRune>()
        .AddIngredient(ItemID.VenusMagnum)
        .AddIngredient(ItemID.SnowballCannon)
        .AddIngredient(ItemID.CandyCornRifle)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}