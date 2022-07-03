using Terraria.ID;
using Yggdrasil.Configs;
using Yggdrasil.Content.Items.Runes.Minor;
using Yggdrasil.Content.Tiles.Furniture;
using Yggdrasil.Runes;
using Yggdrasil.Runes.Effects;

namespace Yggdrasil.Content.Items.Runes.Normal;

internal class WunjoRune : Rune
{
    public const string RuneName = "Wunjo";

    private const float DamageReductionBonus = 0.05f;

    public override string Label => RuneName;

    public override RuneTier Tier => RuneTier.Normal;

    public override string TooltipDescription => RuneEffectConfig.WunjoDescription;

    public override int Rarity => ItemRarityID.LightRed;

    public override int Value => 1000;

    public override void AddRecipes() => CreateRecipe()
        .AddIngredient<MinorWunjoRune>()
        .AddIngredient(ItemID.FrozenTurtleShell)
        .AddIngredient(ItemID.SkeletronPrimeTrophy)
        .AddIngredient(ItemID.HallowedBar, 30)
        .AddTile<DvergrForgeTile>()
        .Register();

    protected override void AddEffects()
    {
        AddEffect(RuneEffects.Get<WunjoEffect>(), new WunjoEffect.Parameters(DamageReductionBonus));
    }
}