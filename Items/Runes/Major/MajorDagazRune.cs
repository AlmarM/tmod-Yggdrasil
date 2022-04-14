using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorDagazRune : DagazRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting awareness.";

    protected override float rangeDamageAmount => 0.2f;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<DagazRune>(3)
        .AddIngredient(ItemID.ShroomiteBar, 40)
        .AddIngredient(ItemID.SniperScope)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
}