using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class AlgizRune : Rune
{
    public const string RuneName = "Algiz";

    private const int DefenseBonus = 2;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.AlgizDescription;

    public override int Rarity => ItemRarityID.Lime;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorAlgizRune>(3)
        .AddIngredient(ItemID.HallowedBar, 10)
        .AddIngredient(ItemID.TurtleShell)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<AlgizEffect>(), new AlgizEffect.Parameters(DefenseBonus));
    }
}