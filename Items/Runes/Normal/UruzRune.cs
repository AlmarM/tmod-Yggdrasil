using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class UruzRune : Rune
{
    public override string RuneName => "Uruz";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting speed.";
	
	public override int RunePower => 1;

    protected virtual float meleeSpeed => 0.1f;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.LightRed;
    }
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorUruzRune>(3)
        .AddIngredient(ItemID.TitanGlove)
        .AddIngredient(ItemID.SoulofFlight, 20)
		.AddTile(TileID.Anvils)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new MeleeSpeedModifier(meleeSpeed));
    }
}