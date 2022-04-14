using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorThurisazRune : ThurisazRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting spikes.";

    protected override float thornsAmount => 0.5f;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<ThurisazRune>(3)
        .AddIngredient(ItemID.WoodenSpike, 10)
        .AddIngredient(ItemID.ThornHook)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
}