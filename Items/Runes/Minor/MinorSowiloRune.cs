using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Minor;

public class MinorSowiloRune : SowiloRune
{
    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => "A minor rune granting success.";

    protected override int armorPenetration => 1;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient(ItemID.StoneBlock, 10) // temporary
        .AddIngredient(ItemID.SharkToothNecklace)
        .AddIngredient(ItemID.Cactus, 15)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Blue;
    }
}