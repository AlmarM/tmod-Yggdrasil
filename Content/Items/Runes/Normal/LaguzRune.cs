using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class LaguzRune : Rune
{
    public const string RuneName = "Laguz";

    private const int HealthRestored = 3;
    private const float HealInterval = 10f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.LaguzDescription;

    public override int Rarity => ItemRarityID.Lime;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorLaguzRune>()
        .AddIngredient(ItemID.GreaterHealingPotion, 10)
        .AddIngredient(ItemID.LifeFruit, 2)
        .AddIngredient(ItemID.SoulofMight, 15)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<LaguzEffect>(true), new LaguzEffect.Parameters(HealthRestored, HealInterval));
    }
}