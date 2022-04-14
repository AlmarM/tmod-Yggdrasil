using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorJeraRune : JeraRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting peace.";

    protected override int aggroAmount => 100;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<JeraRune>(3)
        .AddIngredient(ItemID.PsychoKnife)
        .AddIngredient(ItemID.ShroomiteBar, 10)
		.AddTile(TileID.Anvils)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
}