using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class EihwazRune : Rune
{
    public override string RuneName => "Eihwaz";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting strength.";
	
	public override int RunePower => 1;

    protected virtual float meleeDamageAmount => 0.1f;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.LightRed;
    }
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorEihwazRune>(3)
        .AddIngredient(ItemID.WarriorEmblem)
        .AddIngredient(ItemID.Chik)
		.AddTile(TileID.Anvils)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new MeleeDamageModifier(meleeDamageAmount));
    }
}