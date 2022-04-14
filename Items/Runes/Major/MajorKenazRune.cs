using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorKenazRune : KenazRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting vision.";

    protected override int dodgeChance => 3;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<KenazRune>(3)
        .AddIngredient(ItemID.Tabi)
        .AddIngredient(ItemID.BlackBelt)
		.AddIngredient(ItemID.BlackFairyDust)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Lime;
    }
}