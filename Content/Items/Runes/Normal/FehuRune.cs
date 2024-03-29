using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class FehuRune : Rune<FehuRune>
{
    public const string RuneName = "Fehu";

    private const int CritChanceBonus = 2;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.FehuDescription;

    public override int Rarity => ItemRarityID.Pink;

    public override int Value => 1000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorFehuRune>()
        .AddIngredient(ItemID.HallowedPlateMail)
        .AddIngredient(ItemID.MoonCharm)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<FehuEffect>(), new FehuEffect.Parameters(CritChanceBonus));
    }
}