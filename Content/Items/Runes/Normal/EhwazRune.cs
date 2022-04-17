using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class EhwazRune : Rune
{
    public const string RuneName = "Ehwaz";

    private const float MovementSpeedBonus = 0.1f;
    private const float MaxSpeedBonus = 0.1f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.EhwazDescription;

    public override int Rarity => ItemRarityID.Orange;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorEhwazRune>(3)
        .AddIngredient(ItemID.AsphaltBlock, 50)
        .AddIngredient(ItemID.SoulofFlight, 20)
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<EhwazEffect>(), new EhwazEffect.Parameters(MovementSpeedBonus, MaxSpeedBonus));
    }
}