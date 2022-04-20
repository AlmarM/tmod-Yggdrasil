using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class GeboRune : Rune
{
    public override string RuneName => "Gebo";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting unity.";
	
	public override int RunePower => 1;

    protected virtual float minionDamageAmount => 0.1f;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Pink;
    }
	
	public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorGeboRune>(3)
        .AddIngredient(ItemID.SummonerEmblem)
        .AddIngredient(ItemID.AncientBattleArmorMaterial) //Forbidden Fragment
		.AddTile(TileID.Anvils)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new MinionDamageModifier(minionDamageAmount));
    }
}