using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorEihwazRune : Rune<MajorEihwazRune>
{
    private const float MeleeDamageBonus = 0.2f;

    public override string Label => EihwazRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorEihwazDescription;

    public override int Rarity => ItemRarityID.LightRed;

    public override int Value => 2000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<EihwazRune>()
        .AddIngredient(ItemID.GolemFist)
        .AddIngredient(ItemID.FlowerPow)
        .AddTile<DvergrPowerForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<EihwazEffect>(), new EihwazEffect.Parameters(MeleeDamageBonus));
    }
}