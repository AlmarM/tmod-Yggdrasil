using Terraria;
using Terraria.ID;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes.Content.Items.Normal;

namespace Yggdrasil.Runes.Content.Items.Major;

public class MajorNauthizRune : NauthizRune
{
    protected override RuneTier Tier => RuneTier.Major;

    protected override float InvincibilityBonus => 0.5f;

    protected override int Rarity => ItemRarityID.Red;

    protected override int Value => Item.sellPrice(silver: 20);

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<NormalNauthizRune>()
        .AddIngredient(ItemID.MartianConduitPlating, 50)
        .AddIngredient(ItemID.Ectoplasm, 10)
        .AddIngredient(ItemID.FragmentVortex, 10)
        .AddTile<DvergrPowerForgeTile>()
        .Register();
}