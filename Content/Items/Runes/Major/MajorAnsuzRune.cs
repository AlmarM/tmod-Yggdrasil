using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorAnsuzRune : Rune
{
    private const int MaxManaBonus = 30;

    public override string Label => AnsuzRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorAnsuzDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<AnsuzRune>()
        .AddIngredient(ItemID.Ectoplasm, 10)
        .AddIngredient(ItemID.HallowedHeadgear)
        .AddTile<DvergrPowerForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<AnsuzEffect>(), new AnsuzEffect.Parameters(MaxManaBonus));
    }
}