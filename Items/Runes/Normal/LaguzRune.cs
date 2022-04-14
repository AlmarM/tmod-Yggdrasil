using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

internal class LaguzRune : Rune
{
    public override string RuneName => "Laguz";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune granting renewal.";

    protected virtual int health => 3;
    protected virtual int time => 10;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Lime;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorLaguzRune>(3)
        .AddIngredient(ItemID.GreaterHealingPotion, 10)
        .AddIngredient(ItemID.LifeFruit, 2)
        .AddIngredient(ItemID.SoulofMight, 2)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new HealthOverTimeModifier(health, time));
    }
}