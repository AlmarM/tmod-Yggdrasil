using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorFehuRune : Rune<MinorFehuRune>
{
    private const int CritChanceBonus = 1;

    public override string Label => FehuRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorFehuDescription;

    public override int Rarity => ItemRarityID.Orange;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.JungleShirt)
        .AddIngredient(ItemID.Ale, 10)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<FehuEffect>(), new FehuEffect.Parameters(CritChanceBonus));
    }
}