using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class OthalaRune : Rune
{
    public const string RuneName = "Othala";

    private const float ReduceAmmoConsumptionBonus = 0.15f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.OthalaDescription;

    public override int Rarity => ItemRarityID.LightPurple;

    public override int Value => 1000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorOthalaRune>()
        .AddIngredient(ItemID.EndlessQuiver)
        .AddIngredient(ItemID.EndlessMusketPouch, 5)
        .AddIngredient(ItemID.DaedalusStormbow)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<OthalaEffect>(), new OthalaEffect.Parameters(ReduceAmmoConsumptionBonus));
    }
}