using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorEihwazRune : EihwazRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting strength.";

    protected override float meleeDamageAmount => 0.2f;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<EihwazRune>(3)
        .AddIngredient(ItemID.GolemFist)
        .AddIngredient(ItemID.FlowerPow)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
}