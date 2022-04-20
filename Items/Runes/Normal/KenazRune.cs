using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class KenazRune : Rune
{
    public override string RuneName => "Kenaz";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A minor rune granting vision.";
	
	public override int RunePower => 1;

    protected virtual int dodgeChance => 2;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Pink;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorKenazRune>(3)
        .AddIngredient(ItemID.SmokeBomb, 10)
        .AddIngredient(ItemID.SoulofSight, 10)
		.AddIngredient(ItemID.DarkShard, 2)
		.AddTile(TileID.Anvils)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new DodgeChanceModifier(dodgeChance));
    }
}