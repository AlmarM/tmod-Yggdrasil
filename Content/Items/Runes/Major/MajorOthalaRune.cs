using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorOthalaRune : Rune<MajorOthalaRune>
{
    private const float ReduceAmmoConsumptionBonus = 0.2f;

    public override string Label => OthalaRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorOthalaDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override int Value => 2000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<OthalaRune>()
        .AddIngredient(ItemID.VenusMagnum)
        .AddIngredient(ItemID.SnowballCannon)
        .AddIngredient(ItemID.CandyCornRifle)
        .AddTile<DvergrPowerForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<OthalaEffect>(), new OthalaEffect.Parameters(ReduceAmmoConsumptionBonus));
    }
}