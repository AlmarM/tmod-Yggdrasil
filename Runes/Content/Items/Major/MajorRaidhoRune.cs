using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorRaidhoRune : RaidhoRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override float RunicAttackSpeedBonus => 0.2f;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<RaidhoRune>()
        .AddIngredient(ItemID.PaladinsHammer)
        .AddIngredient(ItemID.ToxicFlask)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}