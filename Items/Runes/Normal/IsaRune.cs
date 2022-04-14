using Terraria.ID;
using Yggdrasil.Items.Runes.Minor;
using Yggdrasil.Players.Modifiers;

namespace Yggdrasil.Items.Runes.Normal;

internal class IsaRune : Rune
{
    public override string RuneName => "Isa";

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => "A rune giving a challenge.";

    protected virtual float damageBonus => 0.5f;
    protected virtual float healthThreshold => 0.12f;

    public override void SetDefaults()
    {
        base.SetDefaults();

        Item.rare = ItemRarityID.Lime;
    }

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorIsaRune>(3)
        .AddIngredient(ItemID.IlluminantBatBanner)
        .AddIngredient(ItemID.PirateBanner)
        .Register();

    protected override void SetModifiers()
    {
        AddModifier(new DamageBelowHealthModifier(damageBonus, healthThreshold));
    }
}