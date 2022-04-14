using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorRaidhoRune : RaidhoRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting precision.";

    protected override float throwingDamageAmount => 0.2f;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<RaidhoRune>(3)
        .AddIngredient(ItemID.PaladinsHammer)
        .AddIngredient(ItemID.ToxicFlask)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
}