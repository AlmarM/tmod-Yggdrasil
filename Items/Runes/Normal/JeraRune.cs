using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

public class JeraRune : Rune
{
    public override string RuneName => "Jera";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting peace.";

    protected virtual int aggroAmount => 50;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Pink;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorJeraRune>(3)
        .AddIngredient(ItemID.SoulofFright, 10)
        .AddIngredient(ItemID.SoulofNight, 10)
		.AddTile(TileID.Anvils)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new AggroModifier(aggroAmount));
    }
}