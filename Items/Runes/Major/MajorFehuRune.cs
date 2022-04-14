using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorFehuRune : FehuRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting luck.";

    protected override int criticalChanceMeleeAmount => 3;
	protected override int criticalChanceRangedAmount => 3;
	protected override int criticalChanceMagicAmount => 3;
	protected override int criticalChanceThrowingAmount => 3;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FehuRune>(3)
        .AddIngredient(ItemID.SpectreRobe)
        .AddIngredient(ItemID.FrostBreastplate)
		.AddIngredient(ItemID.EyeoftheGolem)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
	
}