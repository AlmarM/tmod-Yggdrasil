using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorPerthroRune : Rune
{
    private const float ApplyBuffChance = 0.03f;
    private const float BuffDuration = 2;

    public override string Label => PerthroRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorPerthroDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<PerthroRune>(3)
        .AddIngredient(ItemID.InfernoFork)
        .AddIngredient(ItemID.Nanites, 50)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<PerthroEffect>(), new PerthroEffect.Parameters(ApplyBuffChance, BuffDuration));
    }
}