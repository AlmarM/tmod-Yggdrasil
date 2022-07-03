using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class TiwazRune : Rune
{
    public const string RuneName = "Tiwaz";

    private const float RunicDamageBonus = 0.2f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.TiwazDescription;

    public override int Rarity => ItemRarityID.Pink;

    public override int Value => 1000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorTiwazRune>()
        .AddIngredient(ItemID.ShadowFlameHexDoll)
        .AddIngredient(ItemID.SoulofFright, 10)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<TiwazEffect>(), new TiwazEffect.Parameters(RunicDamageBonus));
    }
}