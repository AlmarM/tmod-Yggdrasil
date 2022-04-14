using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorUruzRune : UruzRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting speed.";

    protected override float meleeSpeed => 0.25f;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<UruzRune>(3)
        .AddIngredient(ItemID.ButchersChainsaw)
        .AddIngredient(ItemID.PossessedHatchet)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
}