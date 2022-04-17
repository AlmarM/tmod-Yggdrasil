using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorFehuRune : Rune
{
    private const int CritChanceBonus = 3;

    public override string Label => FehuRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorFehuDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<FehuRune>(3)
        .AddIngredient(ItemID.SpectreRobe)
        .AddIngredient(ItemID.FrostBreastplate)
        .AddIngredient(ItemID.EyeoftheGolem)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<FehuEffect>(), new FehuEffect.Parameters(CritChanceBonus));
    }
}