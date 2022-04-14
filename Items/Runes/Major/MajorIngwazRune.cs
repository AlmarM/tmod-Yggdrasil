using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorIngwazRune : IngwazRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting internal growth.";

    protected override int maxLifeAmount => 10;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<IngwazRune>(3)
        .AddIngredient(ItemID.SunStone)
        .AddIngredient(ItemID.MoonStone)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
	
}