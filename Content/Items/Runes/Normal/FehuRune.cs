using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class FehuRune : Rune
{
    public const string RuneName = "Fehu";

    private const int CritChanceBonus = 2;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.FehuDescription;

    public override int Rarity => ItemRarityID.Pink;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorFehuRune>(3)
        .AddIngredient(ItemID.HallowedPlateMail)
        .AddIngredient(ItemID.MoonCharm)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<FehuEffect>(), new FehuEffect.Parameters(CritChanceBonus));
    }
}