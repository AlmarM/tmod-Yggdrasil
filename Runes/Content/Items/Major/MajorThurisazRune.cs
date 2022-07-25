using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorThurisazRune : ThurisazRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override float ThornsBonus => 0.5f;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalThurisazRune>()
        .AddIngredient(ItemID.WoodenSpike, 10)
        .AddIngredient(ItemID.ThornHook)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}