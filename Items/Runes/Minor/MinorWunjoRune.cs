using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Minor;

public class MinorWunjoRune : WunjoRune
{
    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => "A minor rune granting comfort.";

    protected override float damageReduction => 0.01f;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient(Mod, "BlankRune")
        .AddIngredient(ItemID.SkeletronTrophy)
        .AddIngredient(ItemID.HellstoneBar, 20)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Blue;
    }
}