using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class RaidhoRune : Rune
{
    public override string RuneName => "Raidho";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting precision.";

    protected virtual float throwingDamageAmount => 0.1f;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Pink;
    }
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorRaidhoRune>(3)
        .AddIngredient(ItemID.LightDisc)
        .AddIngredient(ItemID.MagicDagger)
		.AddTile(TileID.Anvils)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new ThrowingDamageModifier(throwingDamageAmount));
    }
}