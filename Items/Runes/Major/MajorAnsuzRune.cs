using Terraria.ID;
using Yggdrasil.Items.Runes.Normal;

namespace Yggdrasil.Items.Runes.Major;

public class MajorAnsuzRune : AnsuzRune
{
    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => "A major rune granting wisdom.";

    protected override int manaAmount => 30;
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<AnsuzRune>(3)
        .AddIngredient(ItemID.Ectoplasm, 10)
        .AddIngredient(ItemID.HallowedHeadgear)
        .Register();

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Yellow;
    }
	
}