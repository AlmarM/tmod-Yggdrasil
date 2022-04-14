using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorGeboRune : GeboRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting unity.";

    protected override float minionDamageAmount => 0.2f;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<GeboRune>(3)
        .AddIngredient(ItemID.SpookyWood, 400)
        .AddIngredient(ItemID.PygmyNecklace)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
}