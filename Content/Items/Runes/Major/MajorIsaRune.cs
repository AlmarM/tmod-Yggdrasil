using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorIsaRune : Rune<MajorIsaRune>
{
    private const float DamageBonus = 0.3f;
    private const float HealthThreshold = 0.3f;

    public override string Label => IsaRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorIsaDescription;

    public override int Rarity => ItemRarityID.Cyan;

    public override int Value => 2000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<IsaRune>()
        .AddIngredient(ItemID.LihzahrdBanner)
        .AddIngredient(ItemID.SolarSolenianBanner)
        .AddTile<DvergrPowerForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<IsaEffect>(), new IsaEffect.Parameters(DamageBonus, HealthThreshold));
    }
}