using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorAlgizRune : Rune
{
    private const int DefenseBonus = 3;

    public override string Label => AlgizRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorAlgizDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<AlgizRune>()
        .AddIngredient(ItemID.PaladinsShield)
        .AddIngredient(ItemID.BeetleHusk, 10)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<AlgizEffect>(), new AlgizEffect.Parameters(DefenseBonus));
    }
}