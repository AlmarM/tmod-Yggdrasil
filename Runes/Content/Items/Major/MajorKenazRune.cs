using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorKenazRune : KenazRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override float DodgeChanceBonus => 0.03f;

    protected override int Rarity => ItemRarityID.Lime;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalKenazRune>()
        .AddIngredient(ItemID.Tabi)
        .AddIngredient(ItemID.BlackBelt)
        .AddIngredient(ItemID.BlackFairyDust)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}