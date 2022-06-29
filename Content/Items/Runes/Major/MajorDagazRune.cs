using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorDagazRune : Rune
{
    private const float RangeDamageBoost = 0.2f;

    public override string Label => DagazRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorDagazDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<DagazRune>()
        .AddIngredient(ItemID.ShroomiteBar, 40)
        .AddIngredient(ItemID.SniperScope)
        .AddTile<DvergrPowerForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<DagazEffect>(), new DagazEffect.Parameters(RangeDamageBoost));
    }
}