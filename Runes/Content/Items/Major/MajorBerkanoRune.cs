using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorBerkanoRune : BerkanoRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override int LifeRegenBonus => 8;

    protected override int ManaRegenBonus => 8;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalBerkanoRune>()
        .AddIngredient(ItemID.SpectreMask)
        .AddIngredient(ItemID.SunStone)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}