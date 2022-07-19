using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorEhwazRune : EhwazRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override float MovementSpeedBonus => 0.15f;

    protected override int Rarity => ItemRarityID.Lime;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalEhwazRune>()
        .AddIngredient(ItemID.SpookyHook)
        .AddIngredient(ItemID.IlluminantHook)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}