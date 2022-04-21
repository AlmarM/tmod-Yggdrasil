using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Minor;

public class MinorDagazRune : DagazRune
{
    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => "A minor rune granting awareness.";

    protected override float rangeDamageAmount => 0.05f;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient(Mod, "BlankRune")
        .AddIngredient(ItemID.FossilOre, 25)
        .AddIngredient(ItemID.FlareGun)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Blue;
    }
}