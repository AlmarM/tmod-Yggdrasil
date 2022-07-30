using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorHagalazRune : HagalazRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override float MagicDamageBonus => 0.2f;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalHagalazRune>()
        .AddIngredient(ItemID.StaffofEarth)
        .AddIngredient(ItemID.RazorbladeTyphoon)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}