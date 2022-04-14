using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Minor;

public class MinorThurisazRune : ThurisazRune
{
    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => "A minor rune granting spikes.";

    protected override float thornsAmount => 0.1f;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.StoneBlock, 10) // temporary
        .AddIngredient(ItemID.Cactus, 10)
        .AddIngredient(ItemID.Stinger, 2)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Blue;
    }
}