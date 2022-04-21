using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Minor;

public class MinorFehuRune : FehuRune
{
    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => "A minor rune granting luck.";

    protected override int criticalChanceMeleeAmount => 1;
	protected override int criticalChanceRangedAmount => 1;
	protected override int criticalChanceMagicAmount => 1;
	protected override int criticalChanceThrowingAmount => 1;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient(Mod, "BlankRune")
        .AddIngredient(ItemID.JungleShirt)
        .AddIngredient(ItemID.Ale, 10)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Orange;
    }
}