using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class DagazRune : Rune
{
    public override string RuneName => "Dagaz";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting awareness.";
	
	public override int RunePower => 1;

    protected virtual float rangeDamageAmount => 0.1f;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.LightRed;
    }
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorDagazRune>(3)
        .AddIngredient(ItemID.RangerEmblem)
        .AddIngredient(ItemID.MagicQuiver)
		.AddTile(TileID.Anvils)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new RangeDamageModifier(rangeDamageAmount));
    }
}