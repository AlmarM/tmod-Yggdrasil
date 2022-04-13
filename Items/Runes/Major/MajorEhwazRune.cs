using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorEhwazRune : EhwazRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting transportation.";

    protected override float movSpeedAmount => 0.2f;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<EhwazRune>(3)
        .AddIngredient(ItemID.SpookyHook)
        .AddIngredient(ItemID.IlluminantHook)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Lime;
    }
}