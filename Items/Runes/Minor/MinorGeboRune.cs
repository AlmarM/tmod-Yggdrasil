using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Minor;

public class MinorGeboRune : GeboRune
{
    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => "A minor rune granting unity.";

    protected override float minionDamageAmount => 0.05f;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient(Mod, "BlankRune")
        .AddIngredient(ItemID.BeeWax, 30)
        .AddIngredient(ItemID.ImpStaff)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Orange;
    }
}