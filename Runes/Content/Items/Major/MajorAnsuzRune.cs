using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorAnsuzRune : AnsuzRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override int MaxManaBonus => 30;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalAnsuzRune>()
        .AddIngredient(ItemID.Ectoplasm, 10)
        .AddIngredient(ItemID.HallowedHeadgear)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}