using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorWunjoRune : WunjoRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting comfort.";

    protected override float damageReduction => 0.05f;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<WunjoRune>(3)
        .AddIngredient(ItemID.MartianSaucerTrophy)
        .AddIngredient(ItemID.DukeFishronTrophy)
		.AddIngredient(ItemID.SpectreBar, 20)
		.AddIngredient(ItemID.CelestialShell)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
}