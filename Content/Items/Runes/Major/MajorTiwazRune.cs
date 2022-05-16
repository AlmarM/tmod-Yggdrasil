using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorTiwazRune : Rune
{
    private const float RunicDamageBonus = 0.05f;

    public override string Label => TiwazRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorTiwazDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<TiwazRune>()
        .AddIngredient(ItemID.EldMelter)
        .AddIngredient(ItemID.ChargedBlasterCannon)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<TiwazEffect>(), new TiwazEffect.Parameters(RunicDamageBonus));
    }
}