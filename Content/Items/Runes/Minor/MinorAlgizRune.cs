using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorAlgizRune : Rune
{
    private const int DefenseBonus = 1;

    public override string Label => AlgizRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorAlgizDescription;

    public override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.Shackle)
        .AddIngredient(ItemID.ObsidianSkull)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<AlgizEffect>(), new AlgizEffect.Parameters(DefenseBonus));
    }
}