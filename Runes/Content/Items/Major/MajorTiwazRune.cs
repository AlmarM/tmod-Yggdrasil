using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorTiwazRune : TiwazRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override float RunicDamageBonus => 0.2f;

    protected override int Rarity => ItemRarityID.Yellow;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalTiwazRune>()
        .AddIngredient(ItemID.EldMelter)
        .AddIngredient(ItemID.ChargedBlasterCannon)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}