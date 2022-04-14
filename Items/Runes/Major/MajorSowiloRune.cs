using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorSowiloRune : SowiloRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting success.";

    protected override int armorPenetration => 5;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<SowiloRune>(3)
        .AddIngredient(ItemID.Flairon)
        .AddIngredient(ItemID.LaserDrill)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
}