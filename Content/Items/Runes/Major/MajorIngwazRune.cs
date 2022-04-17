using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorIngwazRune : Rune
{
    private const int HealthBonus = 10;

    public override string Label => IngwazRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorIngwazDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<IngwazRune>(3)
        .AddIngredient(ItemID.SunStone)
        .AddIngredient(ItemID.MoonStone)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<IngwazEffect>(), new IngwazEffect.Parameters(HealthBonus));
    }
}