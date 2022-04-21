using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Minor;

public class MinorIngwazRune : IngwazRune
{
    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => "A minor rune granting internal growth.";

    protected override int maxLifeAmount => 2;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient(Mod, "BlankRune")
        .AddIngredient(ItemID.LifeCrystal)
        .AddIngredient(ItemID.HealingPotion, 5)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Green;
    }
}