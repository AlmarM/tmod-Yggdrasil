using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class HagalazRune : Rune
{
    public override string RuneName => "Hagalaz";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting wrath.";
	
	public override int RunePower => 1;

    protected virtual float magicDamageAmount => 0.1f;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Pink;
    }
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorHagalazRune>(3)
        .AddIngredient(ItemID.SorcererEmblem)
        .AddIngredient(ItemID.MagicalHarp)
		.AddTile(TileID.Anvils)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new MagicDamageModifier(magicDamageAmount));
    }
}