using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorBerkanoRune : BerkanoRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting regeneration.";

    protected override int lifeRegenAmount => 20;
    protected override int manaRegenAmount => 80;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BerkanoRune>(3)
        .AddIngredient(ItemID.SpectreMask)
        .AddIngredient(ItemID.SunStone)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
}