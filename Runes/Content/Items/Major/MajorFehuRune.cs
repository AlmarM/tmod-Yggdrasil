using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorFehuRune : FehuRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override int CritChanceBonus => 3;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalFehuRune>()
        .AddIngredient(ItemID.SpectreRobe)
        .AddIngredient(ItemID.FrostBreastplate)
        .AddIngredient(ItemID.EyeoftheGolem)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}