using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class DagazRune : Rune
{
    public override string RuneName => "Dagaz";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting awareness.";

    protected virtual float rangeDmgAmount => 0.1f;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.LightRed;
    }
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorDagazRune>(3)
        .AddIngredient(ItemID.RangerEmblem)
        .AddIngredient(ItemID.MagicQuiver)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new RangeDmgModifier(rangeDmgAmount));
    }
}