using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class IsaRune : Rune<IsaRune>
{
    public const string RuneName = "Isa";

    private const float DamageBonus = 0.2f;
    private const float HealthThreshold = 0.3f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.IsaDescription;

    public override int Rarity => ItemRarityID.Lime;

    public override int Value => 1000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorIsaRune>()
        .AddIngredient(ItemID.IlluminantBatBanner)
        .AddIngredient(ItemID.PirateBanner)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<IsaEffect>(), new IsaEffect.Parameters(DamageBonus, HealthThreshold));
    }
}