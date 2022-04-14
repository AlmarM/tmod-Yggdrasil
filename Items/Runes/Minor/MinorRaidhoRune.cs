using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Minor;

public class MinorRaidhoRune : RaidhoRune
{
    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => "A minor rune granting precision.";

    protected override float throwingDamageAmount => 0.05f;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.StoneBlock, 10) // temporary
        .AddIngredient(ItemID.FossilOre, 25)
        .AddIngredient(ItemID.Javelin, 100)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Blue;
    }
}