using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorIngwazRune : Rune
{
    private const int HealthBonus = 2;

    public override string Label => IngwazRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorIngwazDescription;

    public override int Rarity => ItemRarityID.Green;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.LifeCrystal)
        .AddIngredient(ItemID.HealingPotion, 5)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<IngwazEffect>(), new IngwazEffect.Parameters(HealthBonus));
    }
}