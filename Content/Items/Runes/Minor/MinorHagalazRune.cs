using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorHagalazRune : Rune
{
    private const float MagicDamageBonus = 0.05f;

    public override string Label => HagalazRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorHagalazDescription;

    public override int Rarity => ItemRarityID.Green;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>()
        .AddIngredient(ItemID.WizardHat)
        .AddIngredient(ItemID.MagicMissile)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<HagalazEffect>(), new HagalazEffect.Parameters(MagicDamageBonus));
    }
}