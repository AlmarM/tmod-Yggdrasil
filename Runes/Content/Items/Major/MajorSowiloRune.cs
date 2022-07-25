using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorSowiloRune : SowiloRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override int ArmorPenetrationBonus => 5;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalSowiloRune>()
        .AddIngredient(ItemID.Flairon)
        .AddIngredient(ItemID.LaserDrill)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}