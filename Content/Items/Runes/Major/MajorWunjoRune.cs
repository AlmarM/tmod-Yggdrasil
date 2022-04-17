using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorWunjoRune : Rune
{
    private const float DamageReductionBonus = 0.05f;

    public override string Label => WunjoRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorWunjoDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<WunjoRune>(3)
        .AddIngredient(ItemID.CelestialShell)
        .AddIngredient(ItemID.MartianSaucerTrophy)
        .AddIngredient(ItemID.DukeFishronTrophy)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<WunjoEffect>(), new WunjoEffect.Parameters(DamageReductionBonus));
    }
}