using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class UruzRune : Rune<UruzRune>
{
    public const string RuneName = "Uruz";

    private const float MeleeSpeedBonus = 0.05f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.UruzDescription;

    public override int Rarity => ItemRarityID.LightRed;

    public override int Value => 1000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorUruzRune>()
        .AddIngredient(ItemID.TitanGlove)
        .AddIngredient(ItemID.SoulofFlight, 20)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<UruzEffect>(), new UruzEffect.Parameters(MeleeSpeedBonus));
    }
}