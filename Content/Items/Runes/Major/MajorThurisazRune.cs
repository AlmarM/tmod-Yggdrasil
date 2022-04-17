using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorThurisazRune : Rune
{
    private const float ThornsBonus = 0.5f;

    public override string Label => ThurisazRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorThurisazDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<ThurisazRune>(3)
        .AddIngredient(ItemID.WoodenSpike, 10)
        .AddIngredient(ItemID.ThornHook)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<ThurisazEffect>(), new ThurisazEffect.Parameters(ThornsBonus));
    }
}