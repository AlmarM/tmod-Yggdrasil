using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorOthalaRune : Rune
{
    private const float ReduceAmmoConsumptionBonus = 0.02f;

    public override string Label => OthalaRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorOthalaDescription;

    public override int Rarity => ItemRarityID.Green;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>(10)
        .AddIngredient(ItemID.Sandgun)
        .AddIngredient(ItemID.JestersArrow, 20)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<OthalaEffect>(), new OthalaEffect.Parameters(ReduceAmmoConsumptionBonus));
    }
}