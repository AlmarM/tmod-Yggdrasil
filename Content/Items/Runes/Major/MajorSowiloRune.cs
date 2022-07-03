using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorSowiloRune : Rune
{
    private const int ArmorPenetrationBonus = 5;

    public override string Label => SowiloRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorSowiloDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override int Value => 2000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<SowiloRune>()
        .AddIngredient(ItemID.Flairon)
        .AddIngredient(ItemID.LaserDrill)
        .AddTile<DvergrPowerForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<SowiloEffect>(), new SowiloEffect.Parameters(ArmorPenetrationBonus));
    }
}