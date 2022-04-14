using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class IngwazRune : Rune
{
    public override string RuneName => "Ingwaz";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting internal growth.";

    protected virtual int maxLifeAmount => 5;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Pink;
    }
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorIngwazRune>(3)
        .AddIngredient(ItemID.LifeFruit)
        .AddIngredient(ItemID.LifeforcePotion, 5)
		.AddTile(TileID.Anvils)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new MaxLifeModifier(maxLifeAmount));
    }
}