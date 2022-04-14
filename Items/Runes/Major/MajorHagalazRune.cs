using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorHagalazRune : HagalazRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting wrath.";

    protected override float magicDamageAmount => 0.2f;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<HagalazRune>(3)
        .AddIngredient(ItemID.StaffofEarth)
        .AddIngredient(ItemID.RazorbladeTyphoon)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
}