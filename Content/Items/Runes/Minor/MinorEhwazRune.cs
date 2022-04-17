using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Materials;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Minor;

internal class MinorEhwazRune : Rune
{
    private const float MovementSpeedBonus = 0.05f;
    private const float MaxSpeedBonus = 0.05f;

    public override string Label => EhwazRune.RuneName;

    public override RuneTier Tier => RuneTier.Minor;

    public override string TooltipDescription => RuneEffectConfig.MinorEhwazDescription;

    public override int Rarity => ItemRarityID.Blue;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<BlankRune>(10)
        .AddIngredient(ItemID.IceBlock, 30)
        .AddIngredient(ItemID.SwiftnessPotion, 5)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<EhwazEffect>(), new EhwazEffect.Parameters(MovementSpeedBonus, MaxSpeedBonus));
    }
}