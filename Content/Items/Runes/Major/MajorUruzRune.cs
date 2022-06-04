using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorUruzRune : Rune
{
    private const float MeleeSpeedBonus = 0.07f;

    public override string Label => UruzRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorUruzDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<UruzRune>()
        .AddIngredient(ItemID.ButchersChainsaw)
        .AddIngredient(ItemID.PossessedHatchet)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<UruzEffect>(), new UruzEffect.Parameters(MeleeSpeedBonus));
    }
}