using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class SowiloRune : Rune
{
    public override string RuneName => "Sowilo";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting success.";

    protected virtual int armorPenetration => 3;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Pink;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorSowiloRune>(3)
        .AddIngredient(ItemID.UnicornHorn, 10)
        .AddIngredient(ItemID.Drax)
		.AddTile(TileID.Anvils)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new ArmorPenetrationModifier(armorPenetration));
    }
}