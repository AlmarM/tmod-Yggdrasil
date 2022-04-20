using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class ThurisazRune : Rune
{
    public override string RuneName => "Thurisaz";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting spikes.";
	
	public override int RunePower => 1;

    protected virtual float thornsAmount => 0.25f;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Lime;
    }
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorThurisazRune>(3)
        .AddIngredient(ItemID.TurtleShell)
        .AddIngredient(ItemID.Spike, 10)
		.AddTile(TileID.Anvils)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new ThornsModifier(thornsAmount));
    }
}