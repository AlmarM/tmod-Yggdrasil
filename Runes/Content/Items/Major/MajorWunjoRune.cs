using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorWunjoRune : WunjoRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override float DamageReductionBonus => 0.07f;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalWunjoRune>()
        .AddIngredient(ItemID.CelestialShell)
        .AddIngredient(ItemID.MartianSaucerTrophy)
        .AddIngredient(ItemID.DukeFishronTrophy)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}