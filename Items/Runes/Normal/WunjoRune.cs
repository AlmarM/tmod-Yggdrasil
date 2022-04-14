using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class WunjoRune : Rune
{
    public override string RuneName => "Wunjo";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting comfort.";

    protected virtual float damageReduction => 0.03f;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.LightRed;
    }
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorWunjoRune>(3)
        .AddIngredient(ItemID.FrozenTurtleShell)
        .AddIngredient(ItemID.SkeletronPrimeTrophy)
		.AddIngredient(ItemID.HallowedBar, 30)
		.AddTile(TileID.Anvils)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new DamageReductionModifier(damageReduction));
    }
}