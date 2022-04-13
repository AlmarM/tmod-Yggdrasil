using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class EhwazRune : Rune
{
    public override string RuneName => "Ehwaz";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting transportation.";

    protected virtual float movSpeedAmount => 0.1f;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Orange;
    }
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorEhwazRune>(3)
        .AddIngredient(ItemID.AsphaltBlock, 50)
        .AddIngredient(ItemID.SoulofFlight, 20)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new MovSpeedModifier(movSpeedAmount));
    }
}