using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Normal;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;
using Yggdrasil.Content.Tiles.Furniture;

namespace Yggdrasil.Content.Items.Runes.Major;

internal class MajorMannazRune : Rune
{
    private const float DamageBonus = 0.2f;
    private const float Distance = 300f;

    public override string Label => MannazRune.RuneName;

    public override RuneTier Tier => RuneTier.Major;

    public override string TooltipDescription => RuneEffectConfig.MajorMannazDescription;

    public override int Rarity => ItemRarityID.Yellow;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MannazRune>()
        .AddIngredient(ItemID.BubbleGun)
        .AddIngredient(ItemID.SolarTablet)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<MannazEffect>(), new MannazEffect.Parameters(DamageBonus, Distance));
    }
}