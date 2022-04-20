using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class AnsuzRune : Rune
{
    public override string RuneName => "Ansuz";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting wisdom.";

    public override int RunePower => 1;

    protected virtual int manaAmount => 20;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Orange;
    }
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorAnsuzRune>(3)
        .AddIngredient(ItemID.NaturesGift)
        .AddIngredient(ItemID.CrystalBall)
		.AddTile(TileID.Anvils)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new MaxManaModifier(manaAmount));
    }
}