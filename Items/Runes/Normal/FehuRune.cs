using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class FehuRune : Rune
{
    public override string RuneName => "Fehu";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting luck.";
	
	public override int RunePower => 1;

    protected virtual int criticalChanceMeleeAmount => 2;
	protected virtual int criticalChanceRangedAmount => 2;
	protected virtual int criticalChanceMagicAmount => 2;
	protected virtual int criticalChanceThrowingAmount => 2;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Pink;
    }
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorFehuRune>(3)
        .AddIngredient(ItemID.HallowedPlateMail)
        .AddIngredient(ItemID.MoonCharm)
		.AddTile(TileID.Anvils)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new CriticalChanceModifier(criticalChanceMeleeAmount, criticalChanceRangedAmount, criticalChanceMagicAmount, criticalChanceThrowingAmount));
    }
}