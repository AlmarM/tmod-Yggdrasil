using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorUruzRune : UruzRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override float MeleeSpeedBonus => 0.2f;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalUruzRune>()
        .AddIngredient(ItemID.ButchersChainsaw)
        .AddIngredient(ItemID.PossessedHatchet)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}