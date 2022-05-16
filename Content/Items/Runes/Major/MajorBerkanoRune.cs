using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorBerkanoRune : Rune
{
    private const int LifeRegenBonus = 8;
    private const int ManaRegenBonus = 8;

    public override string Label => BerkanoRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorBerkanoDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BerkanoRune>()
        .AddIngredient(ItemID.SpectreMask)
        .AddIngredient(ItemID.SunStone)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<BerkanoEffect>(), new BerkanoEffect.Parameters(LifeRegenBonus, ManaRegenBonus));
    }
}