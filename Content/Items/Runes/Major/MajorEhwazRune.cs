using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorEhwazRune : Rune
{
    private const float MovementSpeedBonus = 0.15f;
    private const float MaxSpeedBonus = 0.15f;

    public override string Label => EhwazRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorEhwazDescription;

    public override int Rarity => ItemRarityID.Lime;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<EhwazRune>()
        .AddIngredient(ItemID.SpookyHook)
        .AddIngredient(ItemID.IlluminantHook)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<EhwazEffect>(), new EhwazEffect.Parameters(MovementSpeedBonus, MaxSpeedBonus));
    }
}