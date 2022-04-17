using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorLaguzRune : Rune
{
    private const int HealthRestored = 5;
    private const float HealInterval = 10f;

    public override string Label => LaguzRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorLaguzDescription;

    public override int Rarity => ItemRarityID.Cyan;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<LaguzRune>(3)
        .AddIngredient(ItemID.SpectreHood)
        .AddIngredient(ItemID.SuperHealingPotion, 10)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<LaguzEffect>(true), new LaguzEffect.Parameters(HealthRestored, HealInterval));
    }
}